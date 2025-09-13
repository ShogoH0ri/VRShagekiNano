using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Phone : MonoBehaviour
{
    public bool Talking = false;

    public bool isRinging = false;

    public GameObject TriggerBox;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(TurningPoint);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (TriggerBox.gameObject.CompareTag("Player") && isRinging == false)
        {
            SoundManager.Instance.PlaySound3D("PhoneRing", transform.position);
            isRinging = true;
        }
    }


    public void TurningPoint(ActivateEventArgs arg)
    {
        if (Talking == false)
        {
            SoundManager.Instance.PlaySound3D("PhoneCutOff", transform.position);
            Talking = true;
            isRinging = true;
        }
        else if (Talking == false)
        {
            SoundManager.Instance.PlaySound3D("PhoneCutOff", transform.position);
            Talking = true;
            isRinging = true;
        }
    }

    //    private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Right Hand") && Talking == false)
    //    {
    //        PhoneRinging.Instance.isRinging = true;
    //        SoundManager.Instance.PlaySound3D("PhoneCutOff", transform.position);
    //        Talking = true;
    //    }
    //    else if (other.gameObject.CompareTag("Left Hand") && Talking == false)
    //    {
    //        PhoneRinging.Instance.isRinging = true;
    //        SoundManager.Instance.PlaySound3D("PhoneCutOff", transform.position);
    //        Talking = true;
    //    }
    //}
}
