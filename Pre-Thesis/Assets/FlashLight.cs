using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    public bool ON;
    public bool OFF;
    // Start is called before the first frame update
    void Start()
    {
        OFF = true;
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OFF && Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(true);
            OFF = false;
            ON = true;
        } 

        else if (ON && Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(false);
            OFF = true;
            ON = false;
        }      
    }
}
