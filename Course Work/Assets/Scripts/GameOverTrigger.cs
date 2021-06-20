using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private GameOverMenuBehaivour gameOverMenuBehaivour;

    private void Awake()
    {
        gameOverMenuBehaivour = FindObjectOfType<GameOverMenuBehaivour>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            gameOverMenuBehaivour.GameOver();
           // Debug.Log("Game Over");
        }
    }
}
