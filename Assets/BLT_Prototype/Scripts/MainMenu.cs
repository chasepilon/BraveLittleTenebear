using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SlayerModeSelected()
    {
        //Load game with SlayerMode enabled
        GameController.SelectSlayerMode();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SurvivalModeSelected()
    {
        //Load game with SurvivalMode enabled
        GameController.SelectSurvivalMode();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
