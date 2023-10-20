using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    const string P_IDLE = "Player_Idle";
    const string P_Jump = "Player_Jump";
    const string P_Run = "Player_Run";
    const string P_Fall = "Player_Fall";

    string currentState;

    Animator anim;
    Rigidbody2D rb2d;

    public static PlayerAnimations instance;

    void Awake()
    {
        instance = this;

        anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        if(PlayerController.instance.isGrounded)
        {
            if(rb2d.velocity.x == 0)
            {
                ChangeAnimationState(P_IDLE);
            }

            else
            {
                ChangeAnimationState(P_Run);
            }
        }
        
        if (rb2d.velocity.y > 0 && !PlayerController.instance.isGrounded)
        {
            ChangeAnimationState(P_Jump);
        }

        else if(rb2d.velocity.y < 0 && !PlayerController.instance.isGrounded)
        {
            ChangeAnimationState(P_Fall);
        }
    }


    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }
}
