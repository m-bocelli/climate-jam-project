using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float timeForInvincibility;
    private float time;

    public float Health { get { return health; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;

        if(collision.gameObject.tag == "Enemy" && time >= timeForInvincibility)
        {
            float damage = collision.gameObject.GetComponent<EnemyScript>().GetDamage();
            health -= damage;
            if(health <= 0)
            {
                Debug.Log("You Lose!");
                GameMaster.instance.GoToScene("GameOver");
            }
            else
            {
                Debug.Log("Health: " + health);
            }
            time = 0;
        }
    }
}
