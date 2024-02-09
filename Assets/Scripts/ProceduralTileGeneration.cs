using UnityEngine;

public class ProceduralTileGeneration : MonoBehaviour
{
    [SerializeField] ProceduralTileGeneration instance;
    [SerializeField] GameObject[] islands;
    [SerializeField] int islandTotal;
    [SerializeField] float mapSize;

    int islandCount;

    void Awake () 
    {
        instance = this;
    }

    private void Start()
    {
        GenerateIslands(islandTotal);
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
        while(islandCount <= islandTotal)
        {
            float xPos = Random.Range(-mapSize, mapSize);
            float yPos = Random.Range(-mapSize, mapSize);
            Vector3 randomPos = new Vector3(xPos, transform.position.y, yPos);

            int rng = Random.Range(0, 100);

            if (rng <= 40)
            {
                Instantiate(islands[0], randomPos, Quaternion.identity, transform);
            }
            else if (rng <= 60)
            {
                Instantiate(islands[1], randomPos, Quaternion.identity, transform);
            }
            else
            {
                Instantiate(islands[2], randomPos, Quaternion.identity, transform);
            }
            //Debug.Log("islandCount: " + islandCount);
            islandCount++;
        }
    }

}
