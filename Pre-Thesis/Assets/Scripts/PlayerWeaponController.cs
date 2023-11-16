using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponController : MonoBehaviour
{
    public Weapon[] weapons;
    public GameObject ImageWeapon1;
    public GameObject ImageWeapon2;
    public GameObject ImageWeapon3;

    private int currentWeaponIndex = 0;
    private void Start()
    {       
        
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SetActiveWeapon(0);
            ImageWeapon1.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            SetActiveWeapon(1);
            ImageWeapon1.SetActive(true);

        }
        if (Input.GetKeyDown("3"))
        {
            SetActiveWeapon(2);
            ImageWeapon1.SetActive(true);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            currentWeaponIndex++;
            if (currentWeaponIndex > 2) 
            {
                currentWeaponIndex = 0;
            }
            SetActiveWeapon(currentWeaponIndex);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = 2;
            }
            SetActiveWeapon(currentWeaponIndex);
        }
    }

    public Weapon GetCurrentWeapon() 
    {
        return weapons[currentWeaponIndex];
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
