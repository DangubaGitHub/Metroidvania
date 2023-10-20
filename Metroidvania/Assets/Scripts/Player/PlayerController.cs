using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform groundPoint;
    

    public bool isGrounded;
    [SerializeField] LayerMask groundCheckPoint;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;


    Rigidbody2D rb2d;

    public static PlayerController instance;

    void Awake()
    {
        instance = this;

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2d.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, groundCheckPoint);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if(rb2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if(rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    
        
    
}
