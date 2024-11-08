//Bibliotecas ou Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//						Indicador de Herança
//palavra-chave tipo NomeDaClasse : De Quem Herda
public class Movement : MonoBehaviour //SEMPRE que a classe herdar de MonoBehaviour
                                      //significa que ela trabalha na cena
{
    //variáveis
    //palavra-chave tipo nomeDaVariavel;
    Transform playerObject;
    [Range(0f, 5f)] public float playerSpeed = 2f;
    //Vector3 playerDirection;

    //upgrades no sistema de movimento
    //[Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public float rotationSpeed;
    void Start()
    {
        //todos os preenchimentos de variável e carregamentos iniciais das coisas
        playerObject = gameObject.GetComponent<Transform>();
    }
    void Update() //"efetivamente aonde o jogo roda"
                  //TODO SANTO FRAME 
    {
        MovePlayer();
    }
    //palavra-chave tipo-de-retorno NomeDoMétodo / NomeDaFunção (Parâmetros que a função usa) { }
    private void MovePlayer()
    {                               //x(direita-esquerda)     , y (cima-baixo / pulo), z (frente-trás)
        //playerDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //aplicar o vetor no objeto que vai mover na velocidade correta 
        //e com o tempo independente da taxa de quadros
        //playerObject.position += playerDirection * playerSpeed * Time.deltaTime;//jeito "simples" // fala coloquial
        //playerObject.Translate(playerDirection * playerSpeed * Time.deltaTime);//jeito "elegante" //norma culta
        //outra forma de mover

        //new move
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        if (viewDirection != Vector3.zero)
        {
            orientation.forward = viewDirection;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
            //toca a animação de andar, quando tiver andando
            Player.instance.animationController.MoveAnimation(1f);
        }
        else //caso o player não esteja apertando nada
        {
            //toca a animação parado, quando não tiver andando
            Player.instance.animationController.MoveAnimation(0f);
        }
        playerObject.Translate(inputDirection * playerSpeed * Time.deltaTime);
    }
}