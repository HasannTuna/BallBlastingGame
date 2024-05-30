using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickHealthManager : MonoBehaviour
{
    public GameObject brickDestroyParticle;
    public int brickHealth;
    private Text brickHealthText;
    private GameManager gameManager;
    private ScoreManager score;
    private SoundManager sound;
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        score = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
        brickHealth = gameManager.level;
        brickHealthText = GetComponentInChildren<Text>();
    }


    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        brickHealth = gameManager.level;
    }
    
    void Update()
    {
        brickHealthText.text = "" + brickHealth;
        if(brickHealth<=0 )
        {
            score.IncreaseScore();
            Instantiate(brickDestroyParticle, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            
            //Þekilleri yok etme kýsmý
        }
    }
    void TakeDamage (int damageToTake)
    {
        brickHealth -= damageToTake;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag =="Ball" || other.gameObject.tag =="Extra Ball") 
        {
            sound.ballHit.Play();
            TakeDamage(1);
                
        }
    }
}
