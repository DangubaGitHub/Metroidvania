using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    const string P_IDLE = "Player_Idle";
    const string P_Jump = "Player_Jump";
    const string P_Run = "Player_Run";

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
            if(rb2d.velocity.x < 0.1f && rb2d.velocity.x > -0.1f)
            {
                ChangeAnimationState(P_IDLE);
            }

            else
            {
                ChangeAnimationState(P_Run);
            }
        }
        
        if (rb2d.velocity.y > 0)
        {
            ChangeAnimationState(P_Jump);
        }
    }


    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }
}
