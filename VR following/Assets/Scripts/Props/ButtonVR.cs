using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed = false;

    public GameObject Door;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3 (0.131f, 0.81f, 1.916f);
            presser = other.gameObject;
            onPress.Invoke ();
            SoundManager.Instance.PlaySound2D("Setting");
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0.131f, 0.8312f, 1.916f);
            onRelease.Invoke ();
            isPressed = false;
        }
    }

    public void Destroy()
    {
        Destroy(Door);
        SoundManager.Instance.PlaySound2D("OpeningDoor");
    }

}
