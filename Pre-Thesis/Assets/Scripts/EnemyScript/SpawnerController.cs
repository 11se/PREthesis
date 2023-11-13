using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{
    public int initialMobPerWave = 5;
    public int currentMobPerWave;

    public float spawnDelay = 0.5f;

    public int currentWave =0;
    public float waveCooldown = 10f;

    public bool inCoolDown;
    public float coolDownCounter = 0f;

    public List<Enemy> currentMob;

    public GameObject MonsterPrefab;
    private void Start()
    {
        currentMobPerWave = initialMobPerWave;

        StartNextWaves();
    }

    private void StartNextWaves()
    {
        currentMob.Clear();

        currentWave++;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentMobPerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f,1f),0f, Random.Range(-1f,1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            var Mob = Instantiate(MonsterPrefab,spawnPosition, Quaternion.identity);

            Enemy enemyScript = Mob.GetComponent<Enemy>();

            currentMob.Add(enemyScript);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        List<Enemy> MobToRemove = new List<Enemy>();
        foreach (Enemy Mob in currentMob)
        {
            if (Mob.isDead)
            {
                MobToRemove.Add(Mob);
            }
        }

        foreach (Enemy Mob in MobToRemove)
        {
            currentMob.Remove(Mob);
        }

        MobToRemove.Clear();
    }


}
