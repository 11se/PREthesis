using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int bulletDamage;
    public GameObject impactVFX;
    
    private void OnCollisionEnter(Collision objectHit)
    {
        if (objectHit.gameObject.CompareTag("Target"))
        {
            
            print("hit" + objectHit.gameObject.name + " !");          
            var impact = Instantiate(impactVFX, objectHit.contacts[0].point, Quaternion.identity) as GameObject;
            SoundManager.instance.Hit.Play();
            Destroy(impact, 1);
            Destroy(gameObject);

        }
        if (objectHit.gameObject.CompareTag("Construction"))
        {
            
            print("hit" + objectHit.gameObject.name + " !");
            var impact = Instantiate(impactVFX, objectHit.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy(impact, 1);
            Destroy(gameObject);

        }
        if (objectHit.gameObject.CompareTag("Enemy"))
        {
            objectHit.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);         
            print("Hit Enemy !");
            var impact = Instantiate(impactVFX, objectHit.contacts[0].point, Quaternion.identity) as GameObject;
            SoundManager.instance.Hit.Play();
            Destroy(impact, 1);
            Destroy(gameObject);

        }
       
    }

   
}
