using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public GameObject ElevatorDoor;

    public bool Voiceline = false;
    public bool Voiceline2 = false;
    public bool Voiceline3 = false;
    public bool ElevatorSound = false;
    public bool Playing = false;

    public float count;
    public float speed = 0.1f;

    private Vector3 target = new Vector3(3.73f, 1.865f, -1.91f);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ElevatorDoor.transform.position = Vector3.MoveTowards(ElevatorDoor.transform.position, target, speed * Time.deltaTime);
            count += Time.deltaTime;
            if (Voiceline == false)
            {
                SoundManager.Instance.PlaySound2D("Voiceline3");
                Voiceline = true;
                Voiceline2 = true;
            }
            if (Voiceline2 == true && count >= 9)
            {
                SoundManager.Instance.PlaySound2D("Voiceline4");
                Voiceline2 = false;
                Voiceline3 = true;
            }
            if (Voiceline3 == true && count >= 12.5)
            {
                SoundManager.Instance.PlaySound2D("Voiceline5");
                Voiceline3 = false;
                ElevatorSound = true;
            }
            if(ElevatorSound == true && count >= 16)
            {
                MusicManager.Instance.PlayMusic("Elevator");
                ElevatorSound = false;
            }
            if(count >= 22)
            {
                SceneManager.LoadScene("Hospital");
            }

        }
    }
}
