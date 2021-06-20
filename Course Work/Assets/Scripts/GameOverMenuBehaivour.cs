using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;

public class GameOverMenuBehaivour : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    public AudioMixerSnapshot normalSnaphot;
    public AudioMixerSnapshot inMenuSnaphot;
    PauseBehaivor pauseBehaivor;

    private void Awake()
    {
        pauseBehaivor = FindObjectOfType<PauseBehaivor>();
    }

    public void GameOver()
    {
        inMenuSnaphot.TransitionTo(0.6f);
        pauseBehaivor.isGameOver = true;
        Time.timeScale = 0f;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        normalSnaphot.TransitionTo(0.6f);
        pauseBehaivor.isGameOver = false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        normalSnaphot.TransitionTo(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Scene");
    }
}
