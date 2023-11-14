using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : MonoBehaviour
{
    [SerializeField]
    private Weapon.WeaponModel weaponModel;

    [SerializeField]
    private int bulletAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<PlayerWeaponController>().PickUpWeapon(weaponModel, bulletAmount);
            Destroy(gameObject);
        }
    }
}
