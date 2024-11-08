using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//listinha global de crachás sobre SoilState
public enum SoilState
{
    None, Blocked, Prepared, Planted
}

public class Soil : MonoBehaviour
{
    PlayerInteraction player; //a semente precisa de uma referência para o script do player,
                              //para saber se ele está por perto

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
    //quando algum objeto está no trigger
    void OnTriggerStay(Collider quemEstaNoTrigger)
    {
        /*
            1 - se o chão pode ser arado -> ara o chão
            2 - se tá arado e o player tem semente -> planta a semente
            3 - se tem planta e o player tem água - > rega a planta
             */
        if (soilStatus == SoilState.Blocked)
        {
            return;
        }
        //se o player está preenchido e ele apertou E
        if (player != null && player.interacting == true && soilStatus == SoilState.None)
        {
            Debug.Log("Arando o chão");
            soilStatus = SoilState.Prepared;//ara o chão
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
    //SUBSTITUIR OS MÉTODOS DE TRIGGER POR UM OVERLAPBOX PRA MELHORAR A CONSTRUÇÃO
}