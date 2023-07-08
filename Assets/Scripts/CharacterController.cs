using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpSpeed;
    public bool jumpCheck;

    private bool obstacle;
    private Rigidbody2D rb;
    public bool isJumping;
    public BoxCollider2D player;
    public BoxCollider2D ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        obstacle = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int rbPos = (int)rb.gravityScale;
        Move = 1f;

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        if (jumpCheck && !isJumping && obstacle)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed * rbPos));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacle = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacle = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacle = false;
        }
    }
}
