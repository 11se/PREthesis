using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance{  get; set; }

    public AudioSource PistolShootingSound;
    public AudioSource PistolReloadoutSound;

    public AudioSource SMGShootingSound;
    public AudioSource SMGReloadoutSound;

    public AudioSource ShotgunShootingSound;
    public AudioSource ShotgunReloadoutSound;

    public AudioSource EmptySound;
    public AudioSource Hit;
    
    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch(weapon)
        {
            case WeaponModel.Pistol:
                PistolShootingSound.Play(); 
                break;
            case WeaponModel.SMG:
                SMGShootingSound.Play(); 
                break;
            case WeaponModel.Shotgun:
                ShotgunShootingSound.Play(); 
                break;
        }


    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol:
                PistolReloadoutSound.Play();
                break;
            case WeaponModel.SMG:
                SMGReloadoutSound.Play();
                break;
            case WeaponModel.Shotgun:
                ShotgunReloadoutSound.Play();
                break;
        }    
    }
}
