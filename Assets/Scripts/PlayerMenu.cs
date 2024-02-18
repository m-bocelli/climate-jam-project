using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private CrewManager crewManager;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private TextMeshProUGUI crewText;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "    Speed: " + playerMovement.GetSpeed();
        crewText.text = "    Crew: " + crewManager.GetCrewNum();
    }
}
