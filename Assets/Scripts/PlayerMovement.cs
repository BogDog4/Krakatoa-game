using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpForce = 12f;
    private bool facingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform cornerpos;
    [SerializeField] private Transform cornerJumpLimit;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && IsGrounded() && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // small jump
        }
        Flip();
    }

    private void FixedUpdate()
    {//set the X component of rigidbody velocity to the horiz input times speed value (8)
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y); 
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //creates a circle with radius of .2 centered on groundcheck(touchgrass) that checks if it's touching groundlayer
    }
    
    private void Flip()
    {//if your facing right and pressing left, or vice versa, flip.
        if (facingRight && horizontal <0 || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight; //when flip is initiated, set facingright to true/false
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f; //
            transform.localScale = localScale;
        }
    }
}
