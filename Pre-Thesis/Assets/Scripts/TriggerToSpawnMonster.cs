using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToSpawnMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject _monsterSet;
    public GameObject _CloseArea;

    private void Start()
    {
        _CloseArea.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            _monsterSet.SetActive(true);
            Destroy(gameObject);
            _CloseArea.SetActive(true);
        }
    }
}
