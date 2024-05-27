using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject squareBrick;
    public GameObject triangleBrick;
    public GameObject extraBallPowerUp;
    public int numberOfBricksToStart;
    public int level;
    public List<GameObject> bricksInScene;
    public List<GameObject> ballsInScene;
    private ObjectPool objectPool;
    public int numberOfExtraBallsInRow = 0;

    void Start()
    {

        objectPool=FindAnyObjectByType<ObjectPool>();
        level = 1;
        int numberOfBricksCreated = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
         //toplar bir adet geldiði zaman fonksiyonu durdurmasýný ekle

                int brickToCreate = Random.Range(0, 4);
                if (brickToCreate == 0)
                {
                    bricksInScene.Add(Instantiate(squareBrick, spawnPoints [i].position, Quaternion.identity));
                   
                }
                else if (brickToCreate == 1)
                {
                    bricksInScene.Add(Instantiate(triangleBrick, spawnPoints [i].position, Quaternion.identity));
                   
                }
               else if (brickToCreate == 2 && numberOfExtraBallsInRow==0)
                {
                    bricksInScene.Add(Instantiate(extraBallPowerUp, spawnPoints[i].position, Quaternion.identity));
                    numberOfExtraBallsInRow++;

                }
            numberOfExtraBallsInRow = 0;

        }
    }

    
    void Update()
    {
       
    }
    public void PlaceBricks()
    {
        level++;
        foreach (Transform position in spawnPoints)
        {
            int brickToCreate = Random.Range(0, 3);
            if (brickToCreate == 0)
            {
                GameObject brick = objectPool.GetPooledObject("Square Brick");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 1)
            {

                GameObject brick = objectPool.GetPooledObject("Triangle Brick");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 2 &&numberOfExtraBallsInRow ==0)
            {

                GameObject ball = objectPool.GetPooledObject("Extra Ball Powerup");
                bricksInScene.Add(ball);
                if (ball != null)
                {
                    ball.transform.position = position.position;
                    ball.transform.rotation = Quaternion.identity;
                    ball.SetActive(true);
                }

                numberOfExtraBallsInRow++;
            }
        }

        numberOfExtraBallsInRow = 0;


    }
}
