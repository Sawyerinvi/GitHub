using System;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private EnemyData _data;

    public void Init(EnemyData data)
    {
        _data = data;
        GetComponent<SpriteRenderer>().sprite = _data.MainSprite;
    }
    public float Attack
    {
        get
        {
            return _data.Attack;
        }
        protected set { }
    }
    public static Action<GameObject> OnEnemyOverfly;

    private void Update()
    {
        transform.Translate(Vector3.down * _data.Speed * Time.deltaTime);
        if (transform.position.y < -10 && OnEnemyOverfly != null)
            OnEnemyOverfly(gameObject);
        
    }
}
