using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG; //rigid do player
    public float jumpForce = 10f; // força de pulo
    public float gravityModifier = 1f; // modificidador da gravidade
    public bool isOnGround = true; //o player está no chão ?

    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>(); //associando a variavl ao rg
        Physics.gravity *= gravityModifier; //associando a gravidade do player a variavel


    }

    // Update is called once per frame
    void Update()
    {
        Comandos();
    }

    public void Comandos()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameController.gameOver)
        {
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //pular
            isOnGround = false;


        }
    }

    private void OnCollisionEnter(Collision collision) //ativando a variavel quando o player atingir o chao
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacles"))
        {
            print("Colidiu");
            GameController.gameOver = true;
        }
    }
}
