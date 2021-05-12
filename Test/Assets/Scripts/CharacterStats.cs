using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private Canvas statsBars;
    private Image healthBar;
    private float maxHealth = 100f;
    private float health = 100f;
    private float periodBetweenTics = 1f;

    private void Start()
    {
        healthBar = statsBars.transform.Find("Health Bar").GetComponent<Image>();
        SetHealthBar();
    }

    
    private void FixedUpdate()
    {
        
    }

    public void DamageTaken(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0.1f;
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
        SetHealthBar();

    }

    public void PeriodicDamageTaken(float damagePerSecond, int tics)
    {
        StartCoroutine(DamageTiccing(damagePerSecond / periodBetweenTics, tics));
    }

    private IEnumerator DamageTiccing(float damage, int tics)
    {
        for (int i = 0; i < tics; i++)
        {
            yield return new WaitForSeconds(periodBetweenTics);
            health -= damage;
            if (health <= 0)
            {
                health = 0.1f;
            }
            if (health >= maxHealth)
            {
                health = maxHealth;
            }
            SetHealthBar();
        }
        
        
    }


    private void SetHealthBar()
    {
        healthBar.fillAmount = health / maxHealth;

    }
    

}
