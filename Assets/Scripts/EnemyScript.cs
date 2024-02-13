using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Stats"), SerializeField]
    private float health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    //private Rigidbody rb;


    [Header("References"), SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //rb = this.gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, step);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void ReduceHealth(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
