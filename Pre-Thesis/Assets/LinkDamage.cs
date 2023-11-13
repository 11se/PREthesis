using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkDamage : MonoBehaviour
{
    public int BFGDamage = 1000;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(BFGDamage);
            print("Hit Enemy !");


        }
    }
}
