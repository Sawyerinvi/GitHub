using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemies/Enemy", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private Sprite _mainSprite;
    [SerializeField] private float _speed;
    [SerializeField] private float _attack;
    [SerializeField] private float _score;
    public Sprite MainSprite
    {
        get
        {
            return _mainSprite;
        }
        protected set { }
    }
    public float Speed
    {
        get
        {
            return _speed;
        }
        protected set { }
    }
    public float Attack
    {
        get
        {
            return _attack;
        }
        protected set { }
    }

    public float Score
    {
        get
        {
            return _score;
        }
        protected set { }
    }
}
