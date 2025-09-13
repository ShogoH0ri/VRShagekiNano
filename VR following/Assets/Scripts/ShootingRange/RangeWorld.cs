using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class RangeWorld : MonoBehaviour
{
    public static RangeWorld instance;

    public int killCount;

    public GameObject Elevator;
    public Transform spawnPointForElevator;
    public bool spawned = false;

    public Slider musicSlider;
    public Slider sfxSlider;
    OptionMenu menu;

    private void Awake()
    {
        if(instance == null)
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
        //OptionMenu.instance.LoadVolume();

        SoundManager.Instance.PlaySound2D("Voiceline1");

    }

    // Update is called once per frame
    void Update()
    {
        if (killCount == 7 && spawned == false)
        {
            Debug.Log(killCount);
            SpawningElevator();
            spawned = true;
            SoundManager.Instance.PlaySound2D("Voiceline2");

        }
    }

    public void SpawningElevator()
    {
        GameObject spawnElevator = Instantiate(Elevator);
        spawnElevator.transform.position = spawnPointForElevator.transform.position;
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
