using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_IslanderSaved : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI islanderSavedText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateSavedIslanders), 0.1f, 0.1f);
    }

    // Update is called once per frame
    void UpdateSavedIslanders()
    {
        islanderSavedText.SetText(
            GameMaster.instance.savedIslanderCount +
            "/" + 
            GameMaster.instance.totalIslanders);
    }
}
