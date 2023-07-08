using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpSpeed;
    public float maxSpeed = 2;


    public bool jumpCheck;
    public bool dashCheck;

    public GameObject lostPanel;
    public Rigidbody2D rb;

    private bool obstacle;
    public bool isJumping;
    private bool isStopped;

    IEnumerator temp;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        obstacle = false;
        temp = stoppedCheck();
        StartCoroutine(temp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            int rbPos = (int)rb.gravityScale;
            Move = 1f;

            //rb.velocity = new Vector2(speed * Move, rb.velocity.y);

            rb.AddForce(new Vector2 (speed*Move, rb.velocity.y));
            if (jumpCheck && !isJumping && obstacle)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed * rbPos));
            }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0, maxSpeed),rb.velocity.y);
        }

        
    }

    IEnumerator stoppedCheck()
    {
        bool flag = true;
        while(flag)
        {
            if (rb.velocity.magnitude > 0)
            {
                Lost(false);
            }
            else
            {
                for(int i=0; i<3;i++)
                yield return new WaitForSeconds(1f);
                flag = false;
                Lost(true);

            }
            yield return null;
        }

        
    }

    void Lost(bool t)
    {
        Physics2D.autoSimulation = false;
        lostPanel.SetActive(t);
        //StopAllCoroutines();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            Lost(true);
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
