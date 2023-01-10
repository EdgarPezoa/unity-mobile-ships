using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    GameObject player;
    Health health;

    void Start()
    {
        player = GameObject.Find("Player");
        health = player.GetComponent<Health>();
        InitiateSlider();
    }

    private void Update()
    {
        slider.value = health.getHealth();
    }

    void InitiateSlider()
    {
        slider.minValue = 0;
        slider.maxValue = health.getMaxHealth();
        slider.value = health.getHealth();
    }
}
