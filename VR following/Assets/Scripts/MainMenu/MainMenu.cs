using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject option;
    public InputActionProperty showButton;
    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Main Menu Buttons")]
    public Button optionButton;
    public Button quitButton;
    void Start()
    {
        EnableMainMenu();

        optionButton.onClick.AddListener(EnableOption);
        quitButton.onClick.AddListener(QuitGame);

        MusicManager.Instance.PlayMusic("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        MusicManager.Instance.PlayMusic("Game");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
                  Application.Quit();//ゲームプレイ終了
#endif
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void EnableOption()
    {
        mainmenu.SetActive(false);
        option.SetActive(true);
    }
    public void EnableMainMenu()
    {
        mainmenu.SetActive(true);
        option.SetActive(false);
    }

}
