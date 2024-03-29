using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class OilSpillScript : MonoBehaviour
{

    private float timeToCaptureOil;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeToGrow;

    [SerializeField]
    private float timeToSpawn;
    private float timer;

    private float spawnTimer;

    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeToCaptureOil = Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        this.transform.Translate(this.transform.forward * speed * Time.deltaTime);

        if (timer >= timeToGrow)
        {
            timer = 0;
            timeToCaptureOil += 1f;
            this.transform.localScale += new Vector3(.5f, 0f, .5f);
        }

        if(spawnTimer >= timeToSpawn)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }

    public float GetTimeToCapture()
    {
        return timeToCaptureOil;
    }

    public void RemoveOilSpill()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponentInParent<PlayerMovement>();
            playerMovement.DecreaseSpeed(3);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponentInParent<PlayerMovement>();
            playerMovement.IncreaseSpeed(3);
        }
    }

}