using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    public Rigidbody2D rb2d;

    public Vector2 moveDirection;

    public GameObject bulletImpact;

    void Start()
    {

    }

    void Update()
    {
        rb2d.velocity = moveDirection * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletImpact != null)
        {
            Instantiate(bulletImpact, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
