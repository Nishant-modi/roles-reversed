using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpSpeed;


    public bool jumpCheck;
    public bool dashCheck;

    public GameObject lostPanel;
    private Rigidbody2D rb;

    private bool obstacle;
    public bool isJumping;
    private bool isStopped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        obstacle = false;
        StartCoroutine(stoppedCheck());
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

    IEnumerator stoppedCheck()
    {
        if (rb.velocity.x > 0)
        {
            isStopped = true;
            Debug.Log("moving");
        }
        else
        {
            isStopped = false;
            Debug.Log("stopped");
        }
        yield return null;
    }

    void Lost()
    {
        lostPanel.SetActive(true);
        StopAllCoroutines();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            Lost();
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
