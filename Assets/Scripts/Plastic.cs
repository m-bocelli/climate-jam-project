using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastic : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Anim.Play("ship_upgrade");
            playerHealth.BoatSounds.PlasticSound.Play();
            other.GetComponent<CannonFiring>().Ammo += 2;
            Destroy(gameObject);
        }
    }
}
