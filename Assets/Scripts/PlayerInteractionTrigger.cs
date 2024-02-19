using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteractionTrigger : MonoBehaviour
{
    [Header("- Crew Details -")]
    [SerializeField]
    private CrewManager crewManager;
    [Header("Small Islands")]
    [SerializeField]
    private int smallIslandMinCrewGain;
    [SerializeField]
    private int smallIslandMaxCrewGain;
    [SerializeField]
    private float timeToCaptureSmallIsland;
    [Header("Medium Islands")]
    [SerializeField]
    private int mediumIslandMinCrewGain;
    [SerializeField]
    private int mediumIslandMaxCrewGain;
    [SerializeField]
    private float timeToCaptureMediumIsland;
    [Header("Large Islands")]
    [SerializeField]
    private int largeIslandMinCrewGain;
    [SerializeField]
    private int largeIslandMaxCrewGain;
    [SerializeField]
    private float timeToCaptureLargeIsland;

    [Header("Player UI")]
    [SerializeField]
    private Slider captureSlider;
    [SerializeField]
    private GameObject captureSliderGameObject;

    [SerializeField]
    private BoatSounds boatSounds;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "SampleScene") return;

        timer = 0;
        captureSlider.value = 0;
        captureSliderGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "IsladMedium")
        {
            boatSounds.CrewSound();
        }
        else if(other.gameObject.tag == "Oil")
        {
            boatSounds.OilSound();
        }
        else if(other.gameObject.tag == "Enemy")
        {
            boatSounds.EnemyApproachingSound();
        }
        else if(other.gameObject.tag == "OilRig")
        {
            boatSounds.OilRigSound();
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "IslandMedium")
        {
            Island island = other.GetComponent<Island>();
            island.RemoveIslanders(gameObject);

        }
        else if (other.gameObject.tag == "Oil")
        {
            timer += Time.deltaTime * crewManager.GetCrewNum();
            captureSliderGameObject.SetActive(true);
            captureSlider.value = timer / other.gameObject.GetComponent<OilSpillScript>().GetTimeToCapture();
            if (timer <= other.gameObject.GetComponent<OilSpillScript>().GetTimeToCapture()) return;
            other.gameObject.GetComponent<OilSpillScript>().RemoveOilSpill();
            timer = 0;
            captureSlider.value = 0;
            captureSliderGameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "IslandSmall" || other.gameObject.tag == "IslandMedium" || other.gameObject.tag == "IslandLarge" ||
            other.gameObject.tag == "Oil")
        {
            timer = 0;
            captureSlider.value = 0;
            captureSliderGameObject.SetActive(false);
        }
    }
}
