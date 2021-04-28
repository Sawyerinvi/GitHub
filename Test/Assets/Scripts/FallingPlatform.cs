using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    GameObject player, bottom;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == player.name)
        {
            Debug.Log("SAme");
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
        Debug.Log("Coroutine happens");
        
        yield return new WaitForSeconds(1f);
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

    }
}
