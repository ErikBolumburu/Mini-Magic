using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void Play(){
        SceneManager.LoadScene("Levels");
    }

    public void PlayNecromancer(){
        SceneManager.LoadScene("Necromancer_Boss");
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit(){
        Application.Quit();
    }

}