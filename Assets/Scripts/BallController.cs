using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public enum ballState
    {
        //oyun ilerleyiþine göre oyuncunun o anki durumunu özetleyen deðiþkenler (ref1)
        aim,
        fire,
        wait,
        endShot
    }
    public ballState currentBallState;
    public Rigidbody2D ball;
    private Vector2 mouseStartPosition;
    private Vector2 mouseEndPosition;
    private float ballVelocityX;
    private float ballVelocityY;
    public float constantSpeed;
    public GameObject arrow;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        currentBallState = ballState.aim;
    }

    void Update()
    {
        switch (currentBallState)
        {
            //(ref1)  deðiþkenlerin oyun içerisinde görünmesini saðlayan caseler 
            case ballState.aim:
                //kontrollere göre fonksiyonlarý çaðýran kýsým
                if (Input.GetMouseButtonDown(0))
                {
                    MouseClicked();
                }
                if (Input.GetMouseButton(0) )
                {
                    MouseDragged();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    RelaseMouse();

                }
                break;

            case ballState.fire:

                
                break;

            case ballState.wait:
                currentBallState = ballState.endShot;
                break;

            case ballState.endShot:
                
                for(int i = 0; i < gameManager.bricksInScene.Count;i++)
                {
                    gameManager.bricksInScene[i].GetComponent<BrickMovementController>().currentState = BrickMovementController.brickState.move;
                }
                gameManager.PlaceBricks();
                currentBallState= ballState.aim;
                break;



            default:
                
                break; 

        }

        
    }

    public void MouseClicked()
    {
        //mouse ile týklandýðýnda (mobilde ekrana dokunulduðunda) baþlayan pozisyonu açý baþlangýcý olarak alan fonksiyon
        mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log (mouseStartPosition); // mouse un o anki koordinatlarýný gösteren debugger
        
    }

    public void MouseDragged()
    {
        //sürükleme yapýldýkça ilk referans açýdan düz bir þekilde diðer açýyý oluþturmaya yarayan fonksiyon
        
        arrow.SetActive(true);
        Vector2 tempMousePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float diffX = mouseStartPosition.x - tempMousePosition.x;
        float diffY = mouseStartPosition.y - tempMousePosition.y;
        //c# ile oluþturduðumuz açýnýn unity tarafýndan anlaþýlmasý adýna ve eðer týklanan ve sürüklenen kýsým ayný düzlemde olursa oluþabilecek hatayý aþmak adýna eklenen koþul
        if(diffY <= 0)
        {
            diffY = .01f;
        }
        float theta = Mathf.Rad2Deg*Mathf.Atan(diffX / diffY);
        arrow.transform.rotation = Quaternion.Euler( 0f, 0f, -theta);
        //Oku Hareket Ettirme Kýsmý

    }
    public void RelaseMouse()
    {
        //mouse býrakýldýðýnda, býrakýldýðý konumu referans alacak fonksiyon
        arrow.SetActive(false);
        mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x);
        ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y);
        Vector2 tempVelocity= new Vector2 (ballVelocityX, ballVelocityY).normalized;
        ball.velocity = constantSpeed*tempVelocity;
        //eðer ekrana boþ týklanýrsa (ki bu durumda ekranda hiç bir açý olmayacaðýndan fýrlatma açýsý oluþmayacak ve fýrlatma gerçekleþmeyecek) döngüyü tekrarlamasýný saðlayan koþul
        if (ball.velocity == Vector2.zero )
        {
            return;
        }
        currentBallState = ballState.fire;

    }
}
