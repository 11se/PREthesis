using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private int _damage = 25;

   
    //เอาไว้ใช้กับตัวระเบิดได้
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<HealthCont>().TakeDamage(_damage);
            
        }
        Destroy(gameObject);
    }
   

}
    
