using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    public GameObject hitMarker;
    
    // Start is called before the first frame update
    void Start()
    {
        hitMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }
    }
    private void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                HitActive();
                Invoke("HitDeactive", 0.2f);
            }
        }
    }

    private void HitActive()
    {
        hitMarker.SetActive(true);
    }
    private void HitDeactive()
    {
        hitMarker.SetActive(false);
    }
}
