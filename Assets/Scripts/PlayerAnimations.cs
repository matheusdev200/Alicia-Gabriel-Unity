using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    public void MoveAnimation(float speed)
    {
        //chama o animator, acessa o par�metro de "Speed" e entrega pra ele a vari�vel speed
        myAnimator.SetFloat("Speed", speed);
    }
}