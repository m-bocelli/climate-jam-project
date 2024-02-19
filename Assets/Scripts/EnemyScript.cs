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
    [SerializeField] GameObject dropItem;

    [SerializeField] AudioSource enemySource;
    [SerializeField] AudioClip[] enemyClips;

    [SerializeField] AudioClip hitEnemyClip;
    //private Rigidbody rb;


    [Header("References"), SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //rb = this.gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        int rngTiming = Random.Range(15, 30);
        InvokeRepeating(nameof(PlayEnemySound), rngTiming, rngTiming);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, step);
        transform.LookAt(player.transform);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void ReduceHealth(float damage)
    {
        health -= damage;
        enemySource.PlayOneShot(hitEnemyClip);
        CameraShake.instance.ShakeCamera(0.2f, 0.08f);
        Instantiate(dropItem, transform.position, Quaternion.identity);
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayEnemySound()
    {
        int rng = Random.Range(0, enemyClips.Length);
        enemySource.PlayOneShot(enemyClips[rng]);
    }
}
