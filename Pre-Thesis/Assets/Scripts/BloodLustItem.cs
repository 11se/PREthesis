using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BloodLustItem : MonoBehaviour
{
           
    public float BloodPoint = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>() is Projectile player)
        {
            player.playerBlood.currentBlood += BloodPoint;
            player.UpdateBloodText();
            SoundManager.instance.Pickup.Play();
            Destroy(gameObject);
          
        }
    }
   
       
     
}
