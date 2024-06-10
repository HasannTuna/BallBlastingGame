using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
    public GameObject PauseGamePanel;
    private BallController ball;
    //  private bool BallController isPaused;

    void Start()
    {

        ball = FindObjectOfType<BallController>();
        PauseGamePanel.SetActive(false);
    }

    public void Pause()
    {
        ball.isPaused = true;
        //ball.currentBallState = BallController.ballState.pauseGame;
        PauseGamePanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void ResumeGame()
    {
        if (!ball.isPaused)
        {
            return;
        }
        ball.isPaused = false;

        //ball.currentBallState = BallController.ballState.wait;
        PauseGamePanel.SetActive(false);
        Time.timeScale = 1f; // Oyunu devam ettir


    }
    public void Retry()
    {
        SceneManager.LoadScene("Main");

    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");

    }

}
