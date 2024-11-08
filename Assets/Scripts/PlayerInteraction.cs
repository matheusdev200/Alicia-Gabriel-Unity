using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInteraction : MonoBehaviour //vai agir como um inventário temporário
{
    public bool interacting = false;
    public int playerSeeds = 0;

    //"REGADOR" + QUANTIDADE DE ÁGUA
    //public float water = 0f;
    
    void Start()
    {

    }
    void Update()
    {
        interacting = Input.GetKey(KeyCode.E);

        //if (Input.GetKeyDown(KeyCode.E))//pergunta se a tecla E foi apertada
        //{
        //    interacting = true;
        //}
        //if (interacting == true) //= assinala == compara
        //{
        //    interacting = false;
        //}
        //interacting = false;
    }
    public void AddSeed(int seedGained)//ganha sementes
    {
        playerSeeds = playerSeeds + seedGained;
    }
    public void SpendSeed(int seedSpent)//gasta / perde
    {
        //se o player tem sementes pra gastar
        if (playerSeeds > 0) //tentando gastar semente
        {
            playerSeeds = playerSeeds - seedSpent; //gasta
        }
        else
        {
            Debug.Log("Acabaram as sementes");
        }
    }
    //public void UpdateSeeds(int seedChange) //juntando ganhar e gastar num método só
    //{
    //    //se seedChange é negativo && se o player tem sementes o suficiente pra gastar
    //    if (seedChange < 0 && playerSeeds - seedChange >= 0) //tentando gastar semente
    //    {
    //        playerSeeds += seedChange;
    //    }
    //    if (seedChange > 0)//ganhando
    //    {
    //        playerSeeds += seedChange;
    //    }
    //}
}