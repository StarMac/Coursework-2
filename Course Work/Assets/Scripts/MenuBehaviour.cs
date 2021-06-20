using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SoundsSlider;
    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject Options_Menu;


    public void Start()
    {

        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        SoundsSlider.value = PlayerPrefs.GetFloat("UIVolume", 1);

        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("MusicVolume", 1)));
        Mixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("UIVolume", 1)));
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
       // Buttons.SetActive(false);
       // Options_Menu.SetActive(true);
        Buttons.gameObject.SetActive(false);
        Options_Menu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
       // Buttons.SetActive(true);
       // Options_Menu.SetActive(false);
        Options_Menu.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(true);
    }

    public void ChangeVolumeMusic(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80,0,volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeVolumeSounds(float volume)
    {
        Mixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("UIVolume", volume);
    }
}
