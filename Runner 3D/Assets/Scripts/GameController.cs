using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed; //controlar a velocidade do jogo
    public static float timeToSpawn; //controla o tempo de criar novos obstaculos
    public static float score; //score do jogo
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        GameController.speed = 10f;
        GameController.timeToSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        InvokeRepeating("ChangeDificulty", 1f, 5f);
    }

    private void ChangeDificulty()
    {
        GameController.speed += 1;
        GameController.timeToSpawn = Mathf.Clamp(GameController.timeToSpawn - 0.5f, 1.5f, 5f);
        GameController.score += 50;
    }
}
