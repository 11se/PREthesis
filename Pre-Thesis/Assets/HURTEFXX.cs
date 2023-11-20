using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HURTEFXX : MonoBehaviour
{

    public Material HurtMAT;


    private void Start()
    {
        HurtMAT.SetFloat("_FullscreenIntensity", 0);
    }
    public void Onhurt(bool IsHurt)
    {
        
        if(IsHurt == true)
        {
            HurtMAT.SetFloat("_FullscreenIntensity",0.175f);
            
        }
        else
        {
            HurtMAT.SetFloat("_FullscreenIntensity",0);
        }
    }
}
