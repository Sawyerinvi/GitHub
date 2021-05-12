using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IItem
{
    [SerializeField] private GameObject healthPotionPrefab;
    public void Drop(Transform position)
    {
        Instantiate(healthPotionPrefab, position.position, position.rotation);
    }

    public void Use()
    {
        
    }
}
