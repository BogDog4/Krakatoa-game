using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpForce = 12f;
    private bool facingRight = true;
    private bool isWalking = false;
    private bool isSwinging = false; // added boolean to detect left click being held down

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");
        
        isWalking = Mathf.Abs(horizontal) > 0.2f; // checks if the player is moving at least .2

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && IsGrounded() && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // small jump
        }

        // check if left click is being held down
        if (Input.GetMouseButton(0))
        {
            isSwinging = true;
        }
        else
        {
            isSwinging = false;
        }
        
        Flip();
    }

    private void FixedUpdate()
    {
        //set the X component of rigidbody velocity to the horiz input times speed value (8)
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public bool IsJumping()
    {
        bool jumping = rb.velocity.y > 0f;
        Debug.Log("IsJumping: " + jumping);
        return jumping;
    }

    public bool IsFalling()
    {
        bool falling = rb.velocity.y < 0f && !IsGrounded();
        Debug.Log("IsFalling: " + falling);
        return falling;
    }

    private void Flip()
    {
        //if your facing right and pressing left, or vice versa, flip.
        if (facingRight && horizontal < 0 || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight; //when flip is initiated, set facingright to true/false
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f; //flip the whole player prefab backwards
            transform.localScale = localScale;
        }
    }
}


