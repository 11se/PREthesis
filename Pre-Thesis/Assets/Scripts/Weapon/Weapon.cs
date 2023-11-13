using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
      
    //Shooting
    public bool IsShooting, ReadyToShoot;

    bool allowReset = true;

    public float shootingDelay = 2f;
    //Burst
    public int bulletsPerBurst = 6;

    public int BurstBulletsLeft;
    //Spread
    public float spreadIntensity;
    //Bullet
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float bulletVelocity = 10;

    public float bulletPrefablifeTime = 3f;

    private Animator anim;

    //Loading
    public float ReloadTime;

    public int magazineSize, BulletsLeft;

    public bool isReloading;

    public enum WeaponModel
    {
        Pistol,

        SMG,

        Shotgun
    }
    
    public enum ShootingMode
    {
        Single,

        Burst,

        Auto
    }

    public WeaponModel thisModel;
       
    public ShootingMode currentshootingMode;

    private void Awake()
    {
        ReadyToShoot = true;

        BurstBulletsLeft = bulletsPerBurst;

        anim = GetComponent<Animator>();

        BulletsLeft = magazineSize;
    }


    // Update is called once per frame
    void Update()
    {
        if(BulletsLeft ==0 && IsShooting)
        {
            SoundManager.instance.EmptySound.Play();
        }
        
        
        if (currentshootingMode == ShootingMode.Auto)
        {

            IsShooting = Input.GetKey(KeyCode.Mouse0);
            

        }
        else if (currentshootingMode == ShootingMode.Single || currentshootingMode == ShootingMode.Burst)
        {

            IsShooting = Input.GetKeyDown(KeyCode.Mouse0);
            

        }

        if (Input.GetKeyDown(KeyCode.R) && BulletsLeft < magazineSize && isReloading == false && isReloading == false)
        {
            Reload();
            
        }

        /*if (ReadyToShoot && IsShooting == false && isReloading == false && BulletsLeft <= 0)
        {
            Reload();
        }*/

        if (ReadyToShoot && IsShooting && BulletsLeft > 0)
        {
            BurstBulletsLeft = bulletsPerBurst;

            fireWeapon();

        }
        if (AmmoManager.Instance.ammoDisplay != null)
        {
            AmmoManager.Instance.ammoDisplay.text = $"{BulletsLeft / bulletsPerBurst}/{magazineSize/bulletsPerBurst}";
        }

        
    }

    

    private void fireWeapon()
    {
        BulletsLeft--;

        //SoundManager.instance.PistolShootSound.Play();

        SoundManager.instance.PlayShootingSound(thisModel);



        anim.SetTrigger("Shoot");

        ReadyToShoot = false;

        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;

        GameObject bullet = Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.identity);

        bullet.transform.forward = shootingDirection;

        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity,ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefablifeTime));

        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);

            allowReset = false;
        }

        // Burst Mode
        if (currentshootingMode == ShootingMode.Burst && BurstBulletsLeft > 1)
        {
            BurstBulletsLeft --;

            Invoke("fireWeapon",shootingDelay);
        }
    }

    private void Reload()
    {

        //SoundManager.instance.PistolReloadSound.Play();

        SoundManager.instance.PlayReloadSound(thisModel);

        anim.SetTrigger("Reloading");

        isReloading = true;

        Invoke("ReloadCompleted", ReloadTime);
       
    }

    private void ReloadCompleted()
    {
        BulletsLeft = magazineSize;

        isReloading = false;
    }


    private void ResetShot()
    {
        ReadyToShoot = true;

        allowReset = true;
    }

    public Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f,0));

        RaycastHit hit;

        Vector3 targetPoint;

        if(Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - bulletSpawn.position;

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        return direction + new Vector3(x, y, 0);
    }


    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {

        yield return new WaitForSeconds(delay);
        
        Destroy(bullet);

    }
}
