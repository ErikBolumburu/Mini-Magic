using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private GameObject boss;
    public GameObject victoryScreen;
    public bool victory;

    void Start()
    {
       boss = GameObject.FindGameObjectsWithTag("Boss")[0];
    }

    // Update is called once per frame
    void Update()
    {
       if(boss.GetComponent<Enemy>().health <= 0){
            victory = true;
            Destroy(boss);
            victoryScreen.SetActive(true);
       }
    }
}
