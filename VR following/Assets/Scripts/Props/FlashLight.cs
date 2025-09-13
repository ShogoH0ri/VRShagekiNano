using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLight : MonoBehaviour
{
    public GameObject lighting;
    public GameObject enemypopup;
    public Transform spawnPointForEnemy;

    private bool ActivePoint = true;
    private bool ActiveEnemy = false;

    void Start()
    {
        //lighting.gameObject.SetActive(false);
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(TurningPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurningPoint(ActivateEventArgs arg)
    {
        if (ActivePoint == false)
        {
            lighting.gameObject.SetActive(true);
            ActivePoint = true;
            SoundManager.Instance.PlaySound2D("FlashSwitch");
            if(ActiveEnemy == false)
            {
                SoundManager.Instance.PlaySound3D("Popup", transform.position);
                GameObject spawnEnemy = Instantiate(enemypopup);
                spawnEnemy.transform.position = spawnPointForEnemy.position;
                ActiveEnemy = true;
                Destroy(spawnEnemy, 1f);
            }
        }
        else
        {
            SoundManager.Instance.PlaySound2D("FlashSwitch");
            lighting.gameObject.SetActive(false);
            ActivePoint = false;
        }
    }
}
