using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject _bloodBullet;

    public Camera cam;
    public GameObject projectile;
    public GameObject fireBall;

    public Transform Firepoint;

    public float projectileSpeed = 30f;
    public float arcRange = 1;

    public HealthCont playerBlood;
    public float BloodPoint = 20;
    

    public bool hasBloodLust = false;

    private bool rightHand;
    private Vector3 destination;

    private float maxBloodCooldown = 6f;
    private float currentBloodLustCoolDown;

    private float maxShootCooldown = 0.5f;
    private float currentShoottCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        playerBlood = GetComponent<HealthCont>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBloodLust == true)
        {
            currentBloodLustCoolDown -= Time.deltaTime;
            playerBlood.currentBlood = 100*(currentBloodLustCoolDown / maxBloodCooldown);
            UpdateBloodText();

            if (currentBloodLustCoolDown <= 0)
            {
                currentBloodLustCoolDown = 0;
                hasBloodLust = false;
            }
        }
        
        if (playerBlood.currentBlood >= 100)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hasBloodLust = true;
                SoundManager.instance.BloodLustUseSound.Play();
                currentBloodLustCoolDown = maxBloodCooldown;
                UpdateBloodText();
            }
        }
        if(currentShoottCoolDown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                ShootProjectile();
                currentShoottCoolDown = maxShootCooldown;
            }
        }
        else
        {
            currentShoottCoolDown -= Time.deltaTime;
        }
        
    }
    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
            InstantiateProjecttile(Firepoint);      
    }
    void InstantiateProjecttile(Transform Firepoint )
    {       
        if (!hasBloodLust)
        {
            return;            
        }
        
        var projectileObj = Instantiate(fireBall, Firepoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - Firepoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f,2));
    }
    public void UpdateBloodText()
    {
        float BloodBar = (playerBlood.currentBlood / playerBlood.maxBlood);
        playerBlood.BloodLustBar.fillAmount = BloodBar;
    }
}
