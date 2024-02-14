using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    private float damage;

    public float Damage { get { return damage; } set { damage = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().ReduceHealth(damage);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "OilRig")
        {
            collision.gameObject.GetComponent<OilRigScript>().ReduceHealth(damage);
            Destroy(gameObject);
        }
    }
}
