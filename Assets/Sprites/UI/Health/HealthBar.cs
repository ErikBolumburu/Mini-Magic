using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        
    }

    void Update()
    {
       slider.value = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>().health;
    }
}
