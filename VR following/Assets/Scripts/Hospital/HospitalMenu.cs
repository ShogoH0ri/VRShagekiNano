using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalMenu : MonoBehaviour
{
    public static HospitalMenu instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    void Start()
    {
        MusicManager.Instance.PlayMusic("Hospital");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
