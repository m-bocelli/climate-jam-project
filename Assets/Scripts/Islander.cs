using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Islander : MonoBehaviour
{
    [SerializeField] GameObject island;
    [SerializeField] GameObject playerTarget;

    [SerializeField] float travelSpeed;
    [SerializeField] float deleteRange;

    public GameObject Island { get { return island; } set { island = value; } }

    // Start is called before the first frame update
    void Start()
    {
        travelSpeed *= Random.Range(2f, 5f);
        transform.parent = island.gameObject.transform;
    }

    public void SetPlayerTarget(GameObject target)
    {
        playerTarget = target;
    }

    public GameObject GetPlayerTarget()
    {
        return playerTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, Time.deltaTime * travelSpeed);

            if(Vector3.Distance(transform.position, playerTarget.transform.position) < deleteRange)
            {
                GameMaster.instance.savedIslanderCount++;
                GameMaster.instance.GivePlayerUpgrade(playerTarget);
                Destroy(gameObject);
            }
        }
    }
}
