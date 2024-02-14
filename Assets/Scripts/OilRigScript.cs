using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OilRigScript : MonoBehaviour
{
    private bool oilRigDestroyed;
    [SerializeField]
    private float health;

    [SerializeField]
    private float timeToSpawnOil;
    private float timer;

    [SerializeField]
    private GameObject oilSpillPrefab;


    // Start is called before the first frame update
    void Start()
    {
        oilRigDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeToSpawnOil)
        {
            timer = 0;
            Instantiate(oilSpillPrefab, this.gameObject.transform);
        }
    }

    public void ReduceHealth(float damage)
    {
        if (oilRigDestroyed == true) return;

        health -= damage;
        transform.localScale -= new Vector3(0f, .15f, 0f);
        if (health <= 0)
        {
            oilRigDestroyed = true;

        }
    }
}
