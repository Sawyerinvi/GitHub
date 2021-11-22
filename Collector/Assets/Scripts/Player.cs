using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _startingPosition;
    [SerializeField] private float _health;
    [Range(0.01f, 5f)]
    [SerializeField] private float _speed;
    
    public Action<float, FallingObject> OnPlayerHit;

    public float  PlayerHealth { get
        {
            return _health;
        }
    }

    private void Start()
    {
        transform.position = _startingPosition;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -GameCamera.Border)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < GameCamera.Border)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var obj = collision.gameObject;

        

        if (FallerSpawner._fallingObject.ContainsKey(obj))
        {
            

            _health -= FallerSpawner._fallingObject[obj].Attack;

            if(OnPlayerHit != null)
            {
                OnPlayerHit(_health, FallerSpawner._fallingObject[obj]);
            }

            if(_health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Game Over");
            }

            FallingObject.OnEnemyOverfly(obj);

        }
    }
}
