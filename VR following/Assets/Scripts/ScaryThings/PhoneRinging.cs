using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneRinging : MonoBehaviour
{
    public GameObject phone;
    public bool isRinging = false;

    public static PhoneRinging Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isRinging == false)
        {
            SoundManager.Instance.PlaySound3D("PhoneRing", phone.transform.position);
        }
    }

    private void Update()
    {
        Debug.Log(isRinging);
    }
}
