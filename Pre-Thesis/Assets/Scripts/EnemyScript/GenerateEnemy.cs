using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject TheEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

   IEnumerator EnemyDrop()
    {
        while(EnemyCount < 15)
        {
            xPos = Random.Range(1,50);
            zPos = Random.Range(1,31);
            Instantiate(TheEnemy, new Vector3(xPos,11,zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            EnemyCount += 1;
        }
    }
}
