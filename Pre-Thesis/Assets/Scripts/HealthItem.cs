using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    HealthCont playerHealth;
    public TMP_Text healthText;
    public float currentHealth;

    public float health = 15;

    private void Awake()
    {
        playerHealth = FindObjectOfType<HealthCont>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(playerHealth.currentHealth < playerHealth.maxHealth)
            {
                Destroy(gameObject);
                playerHealth.currentHealth = playerHealth.currentHealth + health;
                UpdateHealthText();
            }         
        }
    }
    void UpdateHealthText()
    {
        healthText.SetText($"{(int)playerHealth.currentHealth}");
        Debug.Log(currentHealth.ToString());
    }
}
