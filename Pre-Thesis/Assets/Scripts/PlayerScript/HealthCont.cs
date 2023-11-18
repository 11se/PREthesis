using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.LowLevel;

public class HealthCont : MonoBehaviour
{
    

    [Header("Health Parameter")]
    public float maxHealth = 150f;
    public float currentHealth;
    public float smoothDecreaseDuration = 0.5f;
    Projectile ShoootProjectile;
    Weapon fireshoot;
    bool hasBloodLust = false;
    float cooldownBloodLust = 3.0f;
    public float currentBlood;
    public float maxBlood = 100f;
    public float BloodPoint = 20;

    [Header("UI Parameter")]
    public Image healthBar;
    public Image BloodLustBar;

    public GameObject deathScreen;
    public GameObject player;
    public Animator BloodUI;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("damage");
        BloodUI.SetTrigger("OnAttack");
        StartCoroutine(SmoothDecreaseDuration(damage));
        
    }

    public IEnumerator SmoothDecreaseDuration(float damage)
    {
        float damagePertick = damage / smoothDecreaseDuration;
        float elapsedTime = 0f;

        while (elapsedTime < smoothDecreaseDuration)
        {
            float currentDamage = damagePertick * Time.deltaTime;
            currentHealth -= currentDamage;
            elapsedTime += Time.deltaTime;

            UpdateHealthText();

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                deathScreen.SetActive(true);
                player.GetComponent<CharacterController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            }
            
            if (currentHealth > 150)
            {
                currentHealth = 150;
            }
            yield return null;

        }
    }
    /*void UpdateBloodText()
    {
        float BloodBar = (playerBlood.currentBlood / playerBlood.maxBlood);
        playerBlood.BloodLustBar.fillAmount = BloodBar;
    }*/

    public void UpdateHealthText()
    {
        float healthRate = (currentHealth / maxHealth);
        healthBar.fillAmount = healthRate;
    }
    private void Update()
    {
        if (hasBloodLust)
        {
            //ShootProjectile();
        }
        else
        {
            //Fireshoot();
        }
        /*if(BloodLust == true)
        {
            cooldownBloodLust -= Time.deltaTime;
            if(cooldownBloodLust <= 0)
            {
                hasBloodLust = false;
                cooldownBloodLust = 0;
            }
        }*/
    }
    void OnTriggerEnter()
    {
        /*if(other.collided.name == "Bloodlustitem")
        {
            BloodPoint += 20;
        }
        if(BloodPoint >= 100)
        {
            hasBloodLust = true;
            BloodPoint = 0;
        }*/
    }
    
}
