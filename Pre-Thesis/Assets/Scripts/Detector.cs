using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Link
{
    public GameObject link;
    public Connector connector;
    public string targetName;
}

public class Detector : MonoBehaviour
{
    public GameObject linkPrefab;
    public int BFGDamage = 1000;

    private List<Link> linklist = new List<Link>();

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if(linkPrefab != null)
            {
                Link newlink = new Link() { link = Instantiate(linkPrefab) as GameObject };
                newlink.connector = newlink.link.GetComponent<Connector>();
                newlink.targetName = col.name;
                linklist.Add(newlink);

                if (newlink.connector != null)
                    newlink.connector.MakeConnection(transform.position, col.transform.position);
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if(linklist.Count > 0)
        {
            for(int i = 0; i < linklist.Count; i++)
            {
                if (col.name == linklist[i].targetName)
                    linklist[i].connector.MakeConnection(transform.position, col.transform.position);
            }
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(BFGDamage);
            print("Hit Enemy !");

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (linklist.Count > 0)
        {
            for (int i = 0; i < linklist.Count; i++)
            {
                if (col.name == linklist[i].targetName)
                    Destroy(linklist[i].link);
            }
        }
    }
}
