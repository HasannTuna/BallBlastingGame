using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    private BallController ball;
    public GameObject endGamePanel;
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
     if(other.gameObject.tag == "Square Brick" || other.gameObject.tag == "Triangle Brick")
        {
            ball.currentBallState = BallController.ballState.endGame;
            endGamePanel.SetActive(true);
        }
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
