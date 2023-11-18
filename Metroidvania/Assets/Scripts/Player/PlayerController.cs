using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform groundPoint;
    

    public bool isGrounded;
    [SerializeField] LayerMask groundCheckPoint;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    public BulletController shotToFire;
    public Transform shotPoint;

    public bool isShooting;
    public bool isShootingOnGround;
    private float shootingTimer;
    [SerializeField] float shootDelayTime;

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

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
            
            if (Input.GetButtonDown("Fire1") && shootingTimer >= shootDelayTime && rb2d.velocity.x != 0 && !PlayerAnimations.instance.touchesWall)
            {
                isShooting = true;
                Instantiate(shotToFire, shotPoint.position, shotPoint.rotation). moveDirection = new Vector2(transform.localScale.x, 0f);
            }

            if (Input.GetButtonDown("Fire1") && !isShootingOnGround && rb2d.velocity.x < 0.1f && rb2d.velocity.x > -0.1f && !PlayerAnimations.instance.touchesWall)
            {
                isShootingOnGround = true;
            }
        } 

        if(rb2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if(rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (isShooting)
        {
            shootingTimer -= Time.deltaTime;
        }

        if (shootingTimer <= 0)
        {
            isShooting = false;
            shootingTimer = shootDelayTime;
        }
    }

    public void ShootIdle()
    {
        Instantiate(shotToFire, shotPoint.position, shotPoint.rotation). moveDirection = new Vector2(transform.localScale.x, 0f);
    }
        
    
}
