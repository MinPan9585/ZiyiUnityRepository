using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float directionFactor;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb2d;
    private bool isGrounded = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        directionFactor = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = Vector2.right * directionFactor;
        Vector2 moveVelocity = moveDirection * speed;
        Vector2 jumpVelocity = new Vector2(0, rb2d.velocity.y);
        rb2d.velocity = moveVelocity + jumpVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
