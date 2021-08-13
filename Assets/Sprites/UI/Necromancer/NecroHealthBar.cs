using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NecroHealthBar : MonoBehaviour
{

    public Slider slider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       slider.value = GameObject.FindGameObjectsWithTag("Boss")[0].GetComponent<Enemy>().health;
    }
}
