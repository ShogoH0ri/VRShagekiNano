using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BellRing : MonoBehaviour
{
    public bool DoOnce = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && DoOnce == false)
        {
            SoundManager.Instance.PlaySound2D("ScaryMoment2");
            DoOnce = true;
        }
    }
}
