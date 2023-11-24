using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBomb : MonoBehaviour
{
    [SerializeField]
    private BarrelBombTrigger _barrelBombTrigger;

    [SerializeField]
    private int _damage = 200;

    [SerializeField]
    private GameObject _bombEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullets>()) 
        {
            if (_bombEffect != null) 
            {
                Instantiate(_bombEffect, this.transform.position, Quaternion.identity);
            }

            foreach (Enemy enemy in _barrelBombTrigger.InRangeMonsters) 
            {
                enemy.TakeDamage(_damage);
            }

            Destroy(gameObject);
        }
    }
}
