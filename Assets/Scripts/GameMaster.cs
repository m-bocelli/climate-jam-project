using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [SerializeField]
    private float endTime;
    [SerializeField]
    private Slider timeSlider;
    private float timer;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (instance == null) return;

        timer += Time.deltaTime;
        timeSlider.value = timer / endTime;

        if(timer >= endTime)
        {
            Debug.Log("Game Ended");
        }
    }

    public Vector3 GetRandomPointInCollider(Collider collider, Vector3 offset)
    {
        Vector3 minBounds = new Vector3(collider.bounds.min.x + offset.x, collider.bounds.min.y + offset.x, collider.bounds.min.z + offset.z);
        Vector3 maxBounds = new Vector3(collider.bounds.max.x - offset.x, collider.bounds.max.y - offset.y, collider.bounds.max.z - offset.z);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = offset.y;
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        Vector3 islanderPos = new Vector3(randomX, randomY, randomZ);
        return islanderPos;
    }

    public Vector3 GetRandomSpawnPos(Collider islandCollider, Vector3 offset, GameObject objectToSpawn, string layerMaskName)
    {
        Vector3 spawnPos = Vector3.zero;
        bool validSpawn = false;
        int attemptCount = 0;
        int maxAttempts = 0;

        int noSpawnLayer = LayerMask.NameToLayer(layerMaskName);

        while (!validSpawn && attemptCount <= maxAttempts)
        {
            spawnPos = GetRandomPointInCollider(islandCollider, offset);
            Collider[] colliders = Physics.OverlapBox(spawnPos, objectToSpawn.transform.localScale, Quaternion.identity, noSpawnLayer);

            bool isInvalidCollision = false;
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.layer == noSpawnLayer)
                {
                    isInvalidCollision = true;
                    break;
                }
            }
            if (!isInvalidCollision)
            {
                validSpawn = true;
            } else
            {
                Debug.Log("Failed to Spawn.. Attempt: " + attemptCount);
            }
            attemptCount++;
        }

        return spawnPos;
    }

}
