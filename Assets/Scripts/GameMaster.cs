using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    bool m_Started;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        m_Started = true;
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public Vector3 GetRandomSpawnPos(Collider islandCollider, Vector3 offset, GameObject objectToSpawn, string layerMaskName)
    {
        Vector3 spawnPos = Vector3.zero;
        bool validSpawn = false;
        int attemptCount = 0;
        int maxAttempts = 200;

        int noSpawnLayer = LayerMask.NameToLayer(layerMaskName);

        Debug.Log("hmm");

        while (!validSpawn && attemptCount <= maxAttempts)
        {
            spawnPos = GetRandomPointInCollider(islandCollider, offset);
            Collider[] colliders = Physics.OverlapSphere(spawnPos, 50f);

            Debug.Log("collidersGiven: " + colliders);

            //Gizmos.color = Color.yellow;
            //Gizmos.DrawWireCube(transform.position, objectToSpawn.transform.localScale);

            bool isInvalidCollision = false;
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.layer == noSpawnLayer)
                {
                    Debug.Log("INVALID COLLISION DETECTED");
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


        if (attemptCount >= maxAttempts)
        {
            Debug.Log("max attempts reached..");
        }

        return spawnPos;
    }

}
