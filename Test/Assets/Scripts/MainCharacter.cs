using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private float walkForce, jumpForce, maxVelocity;
    [SerializeField]
    private Rigidbody2D rb;
    private RaycastHit2D raycast;
    private SpriteRenderer sprite;
    

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        IsGrounded();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0)
        {
            rb.AddForce(Vector2.left * walkForce);

            if (rb.velocity.x <= -maxVelocity)
            {
                rb.AddForce(-Vector2.left * walkForce);
            }
        }
        else if(horizontal > 0)
        {
            rb.AddForce(Vector2.right * walkForce);

            if (rb.velocity.x >= maxVelocity)
            {
                rb.AddForce(-Vector2.right * walkForce);
            }
        }
        raycast = Physics2D.Raycast(transform.position - new Vector3(0, sprite.bounds.extents.y + 0.01f, 0), Vector3.down, 0.05f);
        Debug.DrawRay(transform.position - new Vector3(0, sprite.bounds.extents.y + 0.01f, 0), Vector3.down * 0.05f, Color.red);

    }

    private bool IsGrounded()
    {

        if(raycast.collider != null)
        {
            
            return true;

        }
        else
        {
            
            return false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider != null)
        {
            //Debug.Log("Hit Something");
        }
    }
}
