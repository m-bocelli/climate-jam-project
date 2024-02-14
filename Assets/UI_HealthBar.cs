using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBarImage;
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating(nameof(UpdateHealthAmount), 0.1f, 0.1f);
    }

    void UpdateHealthAmount()
    {
        healthBarImage.fillAmount = playerHealth.Health / 100f;
    }
}
