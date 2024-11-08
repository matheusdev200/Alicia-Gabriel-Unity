using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")] public PlayerAnimations animationController;
    public static Player instance; //acesso global do player
    void Start()
    {
        if (instance != this)//Singleton
        {
            Destroy(instance);
        }
        instance = this;

        animationController = GetComponent<PlayerAnimations>();
    }
}