using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Islander : MonoBehaviour
{
    [SerializeField] GameObject island;
    [SerializeField] GameObject playerTarget;

    [SerializeField] float travelSpeed;
    [SerializeField] float deleteRange;

    [SerializeField] Collider bc;
    float extraRaycastHeight = 0.05f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool touchingGround = false;

    [SerializeField] AudioSource helpSource;
    [SerializeField] AudioClip[] helpClips;
    int rngVoiceIdx;

    public GameObject Island { get { return island; } set { island = value; } }

    // Start is called before the first frame update
    void Start()
    {
        travelSpeed *= Random.Range(2f, 5f);
        transform.parent = island.gameObject.transform;

        int rngTiming = Random.Range(3, 5);
        InvokeRepeating(nameof(PlayHelpSound), rngTiming, rngTiming);
        rngVoiceIdx = Random.Range(0, helpClips.Length);
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
            RaycastHit hit;
            Color rayColor = Color.red;
            Vector3 targetPos = playerTarget.transform.position;
            bool hitGround = Physics.Raycast(bc.bounds.center, -Vector2.up, out hit, bc.bounds.extents.y + extraRaycastHeight, groundMask);

            if(hitGround)
            {
                targetPos = new Vector3(playerTarget.transform.position.x, 8f, playerTarget.transform.position.z);
                rayColor = Color.green;
            }
            Debug.DrawRay(bc.bounds.center, -Vector2.up * (bc.bounds.extents.y + extraRaycastHeight), rayColor);

            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * travelSpeed);
            transform.LookAt(playerTarget.transform);
            if (Vector3.Distance(transform.position, playerTarget.transform.position) < deleteRange)
            {
                GameMaster.instance.savedIslanderCount++;
                GameMaster.instance.GivePlayerUpgrade(playerTarget);
                Destroy(gameObject);
            }
        }
    }

    public void PlayHelpSound()
    {
        helpSource.PlayOneShot(helpClips[rngVoiceIdx]);
    }

    void DetectGround()
    {

    }

    void FollowPlayer()
    {

    }
}
