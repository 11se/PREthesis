using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{

    public GameObject DoorWay;
    public GameObject DoorWayClose;
    public GameObject Text;
    public GameObject Text2;
    // Start is called before the first frame update
    void Start()
    {
        DoorWay.SetActive(true);
        Text.SetActive(false);
        Text2.SetActive(false);
        DoorWayClose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorWay.SetActive(false);
            Text.SetActive(true);
            Text2.SetActive(true);
            DoorWayClose.SetActive(false);
        }
    }
}
