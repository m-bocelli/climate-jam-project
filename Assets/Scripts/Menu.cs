using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Credits;

    // Start is called before the first frame update
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickCredits()
    {
        Credits.SetActive(true);
    }
    public void OffClickCredits()
    {
        Credits.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
