using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EndGameManager : MonoBehaviour
{
    private BallController ball;
    public GameObject endGamePanel;
    public GameObject pausebutton;
    public Text scoreText; // Skoru g�sterecek Text bile�eni

    
    void Start()
    {
        ball = FindObjectOfType<BallController>();
        endGamePanel.SetActive(false);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Square Brick" || other.gameObject.tag == "Triangle Brick")
        {
            ball.currentBallState = BallController.ballState.endGame;
            endGamePanel.SetActive(true);
            pausebutton.SetActive(false);
            Time.timeScale = 0f;

            // Skoru g�ncelle
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        // Skor de�erini ScoreManager'dan al ve Text bile�enine ata
        int score = FindObjectOfType<ScoreManager>().GetScore();
       scoreText.text = score.ToString();
       
        



    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}