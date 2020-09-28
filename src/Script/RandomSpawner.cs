using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public List<int> randSpawnCheck = new List<int>();

    // nombre d'objets à apparaître
    public int nbrSpawn;

    void Update()
    {
        // Apparition des bonus/malus/freeze
        if (nbrSpawn > 0)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            if (!randSpawnCheck.Contains(randSpawnPoint))
            {
                Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
                randSpawnCheck.Add(randSpawnPoint);
                nbrSpawn -= 1;
            }
        }
    }
}