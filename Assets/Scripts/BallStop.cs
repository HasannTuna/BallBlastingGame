using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour
{
    public Rigidbody2D ball;
    public BallController ballControl;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //Topu durdur
            ball.velocity = Vector2.zero;
            //leveli sfýrla
            //topu atkif hale getir
            ballControl.currentBallState = BallController.ballState.wait;

        }
    }
}
