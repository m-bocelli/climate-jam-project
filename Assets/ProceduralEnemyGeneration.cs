using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralEnemyGeneration : MonoBehaviour
{

    [SerializeField] ProceduralTileGeneration instance;
    [SerializeField] GameObject[] enemies;

    [SerializeField] Collider seaCollider;
    [SerializeField] int enemyTotal;

    int enemyCount;
    private void Start()
    {
        GenerateIslands(enemyTotal);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            GenerateIslands(enemyTotal);
        }
        */
    }

    void GenerateIslands(int enemyTotal)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        enemyCount = 0;
        while (enemyCount < enemyTotal)
        {
            int rng = Random.Range(0, 100);

            if (rng <= 40)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, enemies[0], "Landform");
                Instantiate(enemies[0], spawnPos, Quaternion.identity, transform);
            }
            else if (rng <= 60)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, enemies[1], "Landform");
                Instantiate(enemies[1], spawnPos, Quaternion.identity, transform);
            }
            else
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, enemies[2], "Landform");
                Instantiate(enemies[2], spawnPos, Quaternion.identity, transform);
            }
            //Debug.Log("islandCount: " + islandCount);
            enemyCount++;
        }
    }
}
