using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_RecycleAmmo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recycleAmmoText;
    [SerializeField] CannonFiring playerCannons;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateSavedIslanders), 0.1f, 0.1f);
    }

    // Update is called once per frame
    void UpdateSavedIslanders()
    {
        if (SceneManager.GetActiveScene().name == "TitleScreen") return;

        recycleAmmoText.SetText(
           playerCannons.Ammo + "");
    }
}
