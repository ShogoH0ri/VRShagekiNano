using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class KeyPadVR : MonoBehaviour
{
    public List<int> correctPassword = new List<int>();
    private List<int> inputPasswordList = new List<int>();
    [SerializeField]
    private TMP_InputField codeDisplay;
    [SerializeField]
    private float resetTime = 2f;
    [SerializeField]
    private string successText;
    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;

    public bool allowMultipleActivations = false;
    private bool hasUsedCorrectCode = false;
    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    public GameObject Door;

    public void UserNumberEntry(int selectedNum)
    {
        if(inputPasswordList.Count >= 4)
        
            return;

            inputPasswordList.Add(selectedNum);

            UpdateDisplay();

        if (inputPasswordList.Count >= 4)
            CheckPassword();
        
    }

    private void CheckPassword()
    {
        for (int i = 0; i < correctPassword.Count; i++)
        {
            if (inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }
        correctPasswordGiven();
    }

    private void correctPasswordGiven()
    {
        if(allowMultipleActivations)
        {
            onCorrectPassword.Invoke();
            codeDisplay.text = successText;
            StartCoroutine(ResetKeyCode());
            SoundManager.Instance.PlaySound2D("OpeningDoor");
            Destroy();
        }
        else if (!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
            SoundManager.Instance.PlaySound2D("OpeningDoor");
            Destroy();
        }
    }

    public void IncorrectPassword()
    {
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetKeyCode());
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for(int i = 0; i < inputPasswordList.Count; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    public void DeleteEntry()
    {
        if (inputPasswordList.Count <= 0)
            return;

        var listposition = inputPasswordList.Count - 1;
        inputPasswordList.RemoveAt(listposition);

        UpdateDisplay();
    }

    IEnumerator ResetKeyCode()
    {
        yield return new WaitForSeconds(resetTime);

        inputPasswordList.Clear();
        codeDisplay.text = "Enter code...";
    }

    public void Destroy()
    {
        Destroy(Door);
    }


    //[SerializeField]
    //private TextMeshProUGUI Answer;

    //private string Correct = "5567";

    //public void Number(int number)
    //{
    //    Answer.text += number.ToString();
    //}

    //public void Execute ()
    //{
    //    if(Answer.text == Correct)
    //    {
    //        Debug.Log("CORRECT");
    //    }
    //    else
    //    {
    //        Answer.text = "INCORRECT";
    //    }
    //}
}
