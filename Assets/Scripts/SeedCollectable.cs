using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CICLO DE DIA-E-NOITE
//CONTADOR DE DIAS DA PLANTA
public class SeedCollectable : MonoBehaviour
{
    PlayerInteraction player; //a semente precisa de uma refer�ncia para o script do player,
                              //para saber se ele est� por perto

    [Header("Colis�o")]
    [Range(0.01f, 0.5f)] public float refreshRate = 0.2f;
    public float radius = 1f;
    public LayerMask playerLayer; //Camada pra F�sica e pra Visibilidade na C�mera
    [Header("Gizmo!")]
    public Color gizmoColor = Color.white;
    void Start()
    {
        StartCoroutine(PlayerCollisionRoutine());
    }
    IEnumerator PlayerCollisionRoutine()
    {
        Collider[] coisas;//verificar os colliders que est�o na esfera
        coisas = Physics.OverlapSphere(transform.position, radius, playerLayer);
        //OnTriggerEnter + OnTriggerStay
        if (coisas.Length > 0)//achou algu�m na camada do player
        {
            player = coisas[0].GetComponent<PlayerInteraction>();//preenche o player
        }
        else //OnTriggerExit
        {
            player = null;
        }
        yield return new WaitForSeconds(refreshRate);
        StartCoroutine(PlayerCollisionRoutine());
    }
    void Update()
    {
        if (player == null)
        {
            return;
        }
        else
        {
            if (player.interacting == true)
            {
                player.AddSeed(1);
                Destroy(gameObject);
            }
        }
    }
    void OnDrawGizmos()//desenha coisas na janela de cena
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    //quando algum objeto entrar no trigger
    //void OnTriggerEnter(Collider quemEntrouNoTrigger)
    //{
    //    player = quemEntrouNoTrigger.GetComponent<PlayerInteraction>(); //preenche o player
    //}
    ////quando algum objeto est� no trigger
    //void OnTriggerStay(Collider quemEstaNoTrigger)
    //{
    //    //se o player est� preenchido e ele apertou E
    //    if (player != null && player.interacting == true)
    //    {
    //        player.AddSeed(1);
    //        Destroy(gameObject);
    //    }
    //}
    ////quando algum objeto sair do trigger
    //void OnTriggerExit(Collider quemSaiuDoTrigger)
    //{
    //    player = null;//remove o player
    //}  KC
}