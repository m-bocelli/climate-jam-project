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
    bool startRemoveIslanders = false;

    public bool StartRemovingIslanders { get {return startRemoveIslanders; } set { startRemoveIslanders = value; } }

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
        islander.GetComponent<Islander>().Island = this.gameObject;
        GameMaster.instance.totalIslanders++;
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

    public void RemoveIslanders(GameObject player)
    {
        //Debug.Log("Remove Islanders called");
        StartCoroutine(RemoveOneIslander(player));
    }

    IEnumerator RemoveOneIslander(GameObject player)
    {
        float rngWaitTime = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(rngWaitTime);
        //Debug.Log("picking random islander to remove...");
        if (islanders.Count <= 0) yield break;
        int rngIdx = Random.Range(0, islanders.Count);
        GameObject randomIslander = islanders[rngIdx];
        //Debug.Log("I choose this Islander!! " + randomIslander.gameObject.transform);

        Islander randomIslanderScript = randomIslander.GetComponent<Islander>();
        randomIslanderScript.SetPlayerTarget(player);
        //Debug.Log("target: " + randomIslanderScript.GetPlayerTarget());
        islanders.RemoveAt(rngIdx);
        RemoveIslanders(player);
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
