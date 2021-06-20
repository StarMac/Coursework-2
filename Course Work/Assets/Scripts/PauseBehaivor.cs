using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class PauseBehaivor : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    public AudioMixerSnapshot normalSnaphot;
    public AudioMixerSnapshot inMenuSnaphot;

    [SerializeField]
    Slider MusicSlider;
    [SerializeField]
    Slider SoundsSlider;
    [SerializeField]
    GameObject PausePanel;
    [SerializeField]
    AudioSource pauseSound;
    private bool gameIsPaused = false;
    private BallLauncher ballLauncher;
    public bool isGameOver = false;
    private void Start()
    {
        ballLauncher = FindObjectOfType<BallLauncher>();
        gameIsPaused = false;
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        SoundsSlider.value = PlayerPrefs.GetFloat("UIVolume", 1);

        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("MusicVolume", 1)));
        Mixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("UIVolume", 1)));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ChangeVolumeMusic(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeVolumeSounds(float volume)
    {
        Mixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("UIVolume", volume);
    }

    public void Pause()
    {
        inMenuSnaphot.TransitionTo(0.6f);
        pauseSound.pitch = 1f;
        pauseSound.PlayOneShot(pauseSound.clip);
        Time.timeScale = 0f;
        gameIsPaused = true;
        PausePanel.gameObject.SetActive(true);
    }

    public void Resume()
    {
        pauseSound.pitch = 0.8f;
        pauseSound.PlayOneShot(pauseSound.clip);

        normalSnaphot.TransitionTo(0.6f);
        ballLauncher.GetComponent<LineRenderer>().startWidth = 0f;
        ballLauncher.GetComponent<LineRenderer>().endWidth = 0f;
        Input.ResetInputAxes();
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void GoToMenu()
    {
        normalSnaphot.TransitionTo(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Scene");
    }
}
