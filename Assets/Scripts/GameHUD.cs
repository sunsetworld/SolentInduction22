using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] Slider sliderValue;
    PlayerHealth player; 

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        sliderValue.value = player.GetHealth() / 1;
    }
}
