using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance{  get; set; }

    public AudioSource ShootingChannel;

    public AudioClip PistolShot;
    public AudioClip SMGShot;
    public AudioClip ShotgunShot;

    public AudioSource PistolReloadoutSound;
    public AudioSource SMGReloadoutSound;
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
                ShootingChannel.PlayOneShot(PistolShot); 
                break;
            case WeaponModel.SMG:
                ShootingChannel.PlayOneShot(SMGShot); 
                break;
            case WeaponModel.Shotgun:
                ShootingChannel.PlayOneShot(ShotgunShot); 
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
