using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float timeForInvincibility;
    private float time;
    [SerializeField] Animator anim;
    [SerializeField] BoatSounds boatSounds;


    public float Health { get { return health; } set { health = value; } }
    public Animator Anim { get { return anim; } }
    public BoatSounds BoatSounds { get { return boatSounds; } }


    // Start is called before the first frame update
    void Start()
    {
        time = timeForInvincibility;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;

        if(collision.gameObject.tag == "Enemy" && time >= timeForInvincibility)
        {
            CameraShake.instance.ShakeCamera(0.5f, 0.6f);
            float damage = collision.gameObject.GetComponent<EnemyScript>().GetDamage();
            health -= damage;
            boatSounds.CrashSound.Play();

            if(health <= 0)
            {
                Debug.Log("You Lose!");
                GameMaster.instance.GoToScene("GameOver");
            }
            else
            {
                Debug.Log("Health: " + health);
                anim.Play("ship_hit_back");
            }
            time = 0;
        }
    }
}
