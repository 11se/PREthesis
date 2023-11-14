using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Weapon[] weapons;

    private int currentWeaponIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SetActiveWeapon(0);
        }
        if (Input.GetKeyDown("2"))
        {
            SetActiveWeapon(1);
        }
        if (Input.GetKeyDown("3"))
        {
            SetActiveWeapon(2);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= 2) 
            {
                currentWeaponIndex = 0;
            }
            SetActiveWeapon(currentWeaponIndex);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            currentWeaponIndex--;
            if (currentWeaponIndex <= 0)
            {
                currentWeaponIndex = 2;
            }
            SetActiveWeapon(currentWeaponIndex);
        }
    }

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

    private void SetActiveWeapon(int index) 
    {
        currentWeaponIndex = index;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (index == i)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else 
            {
                weapons[i].gameObject.SetActive(false);
            }

        }
    }
}
