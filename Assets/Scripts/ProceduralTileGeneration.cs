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
    [SerializeField] float mapSize;

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
            float xPos = Random.Range(-mapSize, mapSize);
            float yPos = Random.Range(-mapSize, mapSize);
            Vector3 randomPos = new Vector3(xPos, transform.position.y, yPos);

            int rng = Random.Range(0, 100);

            if (rng <= 40)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, islands[0], "Landform");
                Instantiate(islands[0], spawnPos, Quaternion.identity, transform);
            }
            else if (rng <= 60)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, islands[1], "Landform");
                Instantiate(islands[1], spawnPos, Quaternion.identity, transform);
            }
            else if (rng <= 80)
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, islands[2], "Landform");
                Instantiate(islands[2], spawnPos, Quaternion.identity, transform);
            } else
            {
                Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, islands[3], "Landform");
                Instantiate(islands[3], spawnPos, Quaternion.identity, transform);
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
            float xPos = Random.Range(-mapSize, mapSize);
            float yPos = Random.Range(-mapSize, mapSize);
            Vector3 randomPos = new Vector3(xPos, transform.position.y, yPos);
            Vector3 spawnPos = GameMaster.instance.GetRandomSpawnPos(seaCollider, Vector3.zero, oilRigPrefab, "Landform");
            Instantiate(oilRigPrefab, spawnPos, Quaternion.identity, transform);
            oilRigCount++;
        }
    }

}
