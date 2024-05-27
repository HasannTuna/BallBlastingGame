using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    private ExtraBallManager extraBallManager;
    void Start()
    {
        extraBallManager = FindAnyObjectByType<ExtraBallManager>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball") 
        {
            //top eklemeyi çalýþtýr
            extraBallManager.numberOfExtraBalls++;
            this.gameObject.SetActive(false);
        }
    }
}
