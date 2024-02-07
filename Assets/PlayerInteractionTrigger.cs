using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
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

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        captureSlider.value = 0;
        captureSliderGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "IslandSmall")
        {
            timer += Time.deltaTime * crewManager.GetCrewNum();
            captureSliderGameObject.SetActive(true);
            captureSlider.value = timer / timeToCaptureSmallIsland;
            if (timer <= timeToCaptureSmallIsland) return;
            crewManager.IncreaseCrewNum(Random.Range(smallIslandMinCrewGain, smallIslandMaxCrewGain));
            timer = 0;
            captureSlider.value = 0;
            captureSliderGameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        else  if (other.gameObject.tag == "IslandMedium")
        {
            timer += Time.deltaTime * crewManager.GetCrewNum();
            captureSliderGameObject.SetActive(true);
            captureSlider.value = timer / timeToCaptureMediumIsland;
            if (timer <= timeToCaptureMediumIsland) return;
            crewManager.IncreaseCrewNum(Random.Range(mediumIslandMinCrewGain, mediumIslandMaxCrewGain));
            timer = 0;
            captureSlider.value = 0;
            captureSliderGameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "IslandLarge")
        {
            timer += Time.deltaTime * crewManager.GetCrewNum();
            captureSliderGameObject.SetActive(true);
            captureSlider.value = timer / timeToCaptureLargeIsland;
            if (timer <= timeToCaptureLargeIsland) return;
            crewManager.IncreaseCrewNum(Random.Range(largeIslandMinCrewGain, largeIslandMaxCrewGain));
            timer = 0;
            captureSlider.value = 0;
            captureSliderGameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "IslandSmall" || other.gameObject.tag == "IslandMedium" || other.gameObject.tag == "IslandLarge")
        {
            timer = 0;
            captureSlider.value = 0;
            captureSliderGameObject.SetActive(false);
        }
    }
}
