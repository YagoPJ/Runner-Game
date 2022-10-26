using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    public GameObject[] obstaclesPreFab; //referenciar o obstaculo
    private Vector3 spawnPos = new Vector3(25, 0, 0);  //distancia dos obstaculos
    private IEnumerator coroutine;
    //[SerializeField]
    //private float startDelay, repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        coroutine = SpawnObstacles();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstacles()
    {
        while(true)
        {
            if (!GameController.gameOver)
            {
                CreateObstacle();
                yield return new WaitForSeconds(GameController.timeToSpawn);
            }
            
        }
    }

    public void CreateObstacle()
    {
        GameObject obstacle = obstaclesPreFab[Random.Range(0, obstaclesPreFab.Length -1)];
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
}
