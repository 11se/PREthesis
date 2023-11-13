using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

    public bool randomDamage;
    public bool SetDamage;

    
    // Start is called before the first frame update
    void Start()
    {
        damageRange = Random.Range(minDamage, maxDamage);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && randomDamage)
        {
            player.GetComponent<HealthCont>().currentHealth -= damageRange;
        }

        if (other.gameObject.tag == "Player" && SetDamage)
        {
            player.GetComponent <HealthCont>().currentHealth += damageSet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
