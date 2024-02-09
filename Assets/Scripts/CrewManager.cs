using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{
    private int crewNum;

    // Start is called before the first frame update
    void Start()
    {
        crewNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCrewNum()
    {
        return crewNum;
    }

    public void IncreaseCrewNum(int num)
    {
        crewNum += num;
    }
}
