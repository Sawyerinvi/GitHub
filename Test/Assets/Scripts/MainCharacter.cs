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

    void Start()
    {
        
    }

    
    void Update()
    {
        raycast = Physics2D.Raycast(transform.position - new Vector3(0, -0.6f, 0), -Vector2.up, 0.1f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * walkForce);

            if(rb.velocity.x <= -maxVelocity)
            {
                rb.AddForce(-Vector2.left * walkForce);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * walkForce);

            if (rb.velocity.x >= maxVelocity)
            {
                rb.AddForce(-Vector2.right * walkForce);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        IsGrounded();
    }

    private bool IsGrounded()
    {

        if(raycast.collider != null)
        {
            Debug.Log("Hit the ground");
            return true;

        }
        else
        {
            Debug.Log("In the air");
            return false;
        }
    }
}
