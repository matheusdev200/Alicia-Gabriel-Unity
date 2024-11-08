using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//listinha global de crach�s sobre SoilState
public enum SoilState
{
    None, Blocked, Prepared, Planted
}

public class Soil : MonoBehaviour
{
    PlayerInteraction player; //a semente precisa de uma refer�ncia para o script do player,
                              //para saber se ele est� por perto

    public SoilState soilStatus = SoilState.None;

    //ACRESCENTAR A HABILIDADE DE ARAR

    //quando algum objeto entrar no trigger
    void OnTriggerEnter(Collider quemEntrouNoTrigger)
    {
        if (soilStatus == SoilState.Blocked)
        {
            return;
        }
        player = quemEntrouNoTrigger.GetComponent<PlayerInteraction>(); //preenche o player
    }
    //quando algum objeto est� no trigger
    void OnTriggerStay(Collider quemEstaNoTrigger)
    {
        /*
            1 - se o ch�o pode ser arado -> ara o ch�o
            2 - se t� arado e o player tem semente -> planta a semente
            3 - se tem planta e o player tem �gua - > rega a planta
             */
        if (soilStatus == SoilState.Blocked)
        {
            return;
        }
        //se o player est� preenchido e ele apertou E
        if (player != null && player.interacting == true && soilStatus == SoilState.None)
        {
            Debug.Log("Arando o ch�o");
            soilStatus = SoilState.Prepared;//ara o ch�o
        }
        if (player != null && player.interacting == true && soilStatus == SoilState.Prepared)
        {
            player.SpendSeed(1);//planta uma semente ali
            soilStatus = SoilState.Planted;
            Debug.Log("1 semente plantada");
        }
        if (player != null && player.interacting == true && soilStatus == SoilState.Planted)
        {
            Debug.Log("Regando semente");
        }
    }
    //quando algum objeto sair do trigger
    void OnTriggerExit(Collider quemSaiuDoTrigger)
    {
        if (soilStatus == SoilState.Blocked)
        {
            return;
        }
        player = null;//remove o player
    }
    //SUBSTITUIR OS M�TODOS DE TRIGGER POR UM OVERLAPBOX PRA MELHORAR A CONSTRU��O
}