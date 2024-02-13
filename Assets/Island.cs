using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    // public delegate void OnIslandDuplicate();
    // public static event OnIslandDuplicate onIslandDuplicate;
    public int islandSize = 0;
    public int islandersOnIsland = 1;
    [SerializeField] BoxCollider bc;
    [SerializeField] GameObject islanderPrefab;
    [SerializeField] Vector3 islanderOffset;

    [SerializeField] List<GameObject> islanders = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < islandersOnIsland; i++)
        {
            GameObject islander = SpawnIslanders();
            islanders.Add(islander);
        }
    }

    public GameObject SpawnIslanders()
    {
        Collider collider = gameObject.GetComponent<Collider>();
        GameObject islander = Instantiate(islanderPrefab, GameMaster.instance.GetRandomSpawnPos(collider, islanderOffset, islanderPrefab, "Islander"), Quaternion.identity);
        return islander;
    }

    public void RemoveIsland()
    {
        foreach (GameObject islander in islanders)
        {
            Destroy(islander);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if(collision.gameObject.tag.StartsWith("Island") || collision.gameObject.tag == "Player")
        {
            //Debug.Log("collision has collided with Island");
            Destroy(gameObject);
        }
        */
    }

}
