using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalV;
    public float speed = 6f;
    public float jumpForce = 12f;
    private bool facingRight = true;

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public GameObject attackPrefab;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontalV = Input.GetAxisRaw("horizontal");
        animator.SetFloat("InputH", Mathf.Abs(horizontalV));
        rb.velocity = new Vector2(horizontalV * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Attack()
    {
        animator.SetTrigger("Swing");

        Instantiate(attackPrefab, attackPoint.position, Quaternion.identity);
        Debug.Log("Attack prefab instantiated!");
    }

    private void Flip()
    {
        if (facingRight && horizontalV < 0 || !facingRight && horizontalV > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}


