using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NoteCont : MonoBehaviour
{
    public GameObject note;
    public TMP_Text noteInUI;
    public TMP_Text noteInUI2;

    public void Start()
    {
        note.SetActive(false);
    }
   
    private void OnTriggerEnter(Collider col)
    {
        note.SetActive(true);
    }

    private void OnTriggerStay(Collider col)
    {
        note.SetActive(true);
    }

    private void OnTriggerExit(Collider col)
    {
        note.SetActive(false);
    }


}
