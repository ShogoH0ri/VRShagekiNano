using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCorpse : MonoBehaviour
{
    public GameObject Key;
    public Transform spawnPoint;

    public bool DoOnce = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife") && DoOnce == false)
        {
            Debug.Log("WORK");
            GameObject spawnKey = Instantiate(Key);
            spawnKey.transform.position = spawnPoint.position;
            SoundManager.Instance.PlaySound2D("Cutting");
            DoOnce = true;
        }
    }
}
