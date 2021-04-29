using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    GameObject bottom;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            
            StartCoroutine(DropThePlatform());           
        }      
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject == bottom)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DropThePlatform()
    {
        yield return new WaitForSeconds(1f);
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

    }
}
