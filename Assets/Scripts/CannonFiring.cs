using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFiring : MonoBehaviour
{
    [Header("Cannons"), SerializeField]
    private GameObject cannonBall;
    [SerializeField]
    private Transform[] attackPoints = new Transform[2];

    [Header("Stats"), SerializeField]
    private float force;
    [SerializeField]
    private float timeToReload;

    private int numOfCannons;
    private bool readyToShoot;
    private float time;

    [Header("References"), SerializeField]
    private CrewManager crewManager;

    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = false;
        numOfCannons = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(crewManager.GetCrewNum() == 1)
        {
            time += Time.deltaTime;
        }
        else
        {
            time += Time.deltaTime * (crewManager.GetCrewNum() / numOfCannons);
        }

        if(Input.GetButton("Fire1") && readyToShoot)
        {
            ShootCannons();
        }

        if(time >= timeToReload)
        {
            readyToShoot = true;
        }
    }

    private void ShootCannons()
    {
        readyToShoot = false;

        foreach (Transform attackPoint in attackPoints)
        {
            GameObject newCannonBall = Instantiate(cannonBall, attackPoint.position, Quaternion.identity);
            newCannonBall.GetComponent<Rigidbody>().AddForce(force * attackPoint.forward, ForceMode.Impulse);
            Destroy(newCannonBall, 3f);
        }

        time = 0;
    }
}
