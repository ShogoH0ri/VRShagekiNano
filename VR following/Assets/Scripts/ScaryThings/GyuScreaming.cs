using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyuScreaming : MonoBehaviour
{
    public GameObject SoundPlace;
    public bool DoOnce = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && DoOnce == false)
        {
            SoundManager.Instance.PlaySound3D("Screaming", SoundPlace.transform.position);
            DoOnce = true;
        }
    }
}
