using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
   // public delegate void OnIslandDuplicate();
   // public static event OnIslandDuplicate onIslandDuplicate;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.StartsWith("Island") || collision.gameObject.tag == "Player")
        {
            //Debug.Log("collision has collided with Island");
            Destroy(gameObject);
        }
    }

}
