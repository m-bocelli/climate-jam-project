using UnityEngine;

public class ProceduralTileGeneration : MonoBehaviour
{
    [SerializeField] ProceduralTileGeneration instance;
    [SerializeField] GameObject[] islands;


    [SerializeField] GameObject oilRigPrefab;
    private GameObject[] oilRigs;

    [SerializeField] Collider seaCollider;
    [SerializeField] int islandTotal;
    [SerializeField] int oilRigTotal;

    int islandCount;
    int oilRigCount;

    void Awake () 
    {
        instance = this;
    }

    private void Start()
    {
        GenerateIslands(islandTotal);
        GenerateOilRigs(oilRigTotal);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GenerateIslands(islandTotal);
        }
    }

    void GenerateIslands(int islandTotal)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        islandCount = 0;
        while(islandCount < islandTotal)
        {

            int rng = Random.Range(0, 100);
            Vector3 offset = new Vector3(-8,0,-8);
            if (rng <= 40)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, offset, islands[0], "Landform");
                Instantiate(islands[0], spawnPos, Quaternion.identity, transform);
            }
            else if (rng <= 60)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, offset, islands[1], "Landform");
                Instantiate(islands[1], spawnPos, Quaternion.identity, transform);
            }
            else
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, offset, islands[2], "Landform");
                Instantiate(islands[2], spawnPos, Quaternion.identity, transform);
            }
            //Debug.Log("islandCount: " + islandCount);
            islandCount++;
        }
    }

    void GenerateOilRigs(int oilRigTotal)
    {
        oilRigCount = 0;
        while (oilRigCount < oilRigTotal)
        {
            Vector3 offset = new Vector3(-8, 8, -8);
            Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, offset, oilRigPrefab, "Landform");
            Instantiate(oilRigPrefab, spawnPos, Quaternion.identity, transform);
            oilRigCount++;
        }
    }

}
