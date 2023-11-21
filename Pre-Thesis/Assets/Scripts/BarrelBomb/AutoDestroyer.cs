using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private float _countDownToDestroy = 1.0f;

    private void Update()
    {
        _countDownToDestroy -= Time.deltaTime;

        if (_countDownToDestroy <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
