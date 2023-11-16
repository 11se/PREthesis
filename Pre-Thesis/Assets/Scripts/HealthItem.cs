using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    HealthCont playerHealth;   

    public float health = 15;

    private void Awake()
    {
        playerHealth = FindObjectOfType<HealthCont>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<HealthCont>() is HealthCont healthcomp) 
            {
                if (healthcomp.currentHealth < healthcomp.maxHealth)
                {
                    healthcomp.currentHealth = healthcomp.currentHealth + health;
                    healthcomp.UpdateHealthText();
                    Destroy(gameObject);
                }
            }
        }
    }
}
