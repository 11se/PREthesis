using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoootProjectile : MonoBehaviour
{
    public GameObject impactVFX;

    public int fireDamage = 60;

    private bool collided;
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Bullet" && col.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, col.contacts[0].point,Quaternion.identity) as GameObject;
            Destroy(impact, 1);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(fireDamage);
            print("Hit Enemy !");


        }
    }
   
}
