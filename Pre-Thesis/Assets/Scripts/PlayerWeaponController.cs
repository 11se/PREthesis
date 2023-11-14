using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Weapon[] weapons;

    public void PickUpWeapon(Weapon.WeaponModel type, int amount) 
    {
        foreach (Weapon weapon in weapons) 
        {
            if (weapon.thisModel == type) 
            {
                weapon.AddBulletLeft(amount);
            }
        }
    }
}
