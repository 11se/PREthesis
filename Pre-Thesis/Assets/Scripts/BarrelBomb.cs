using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBomb : MonoBehaviour
{
    [SerializeField]
    private BarrelBombTrigger _barrelBombTrigger;

    [SerializeField]
    private int _damage = 50;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullets>()) 
        {
            foreach (Enemy enemy in _barrelBombTrigger.InRangeMonsters) 
            {
                enemy.TakeDamage(_damage);
            }

            Destroy(gameObject);
        }
    }
}
