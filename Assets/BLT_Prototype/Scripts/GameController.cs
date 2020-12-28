using System.Collections;
using System.Collections.Generic;
using Gamekit2D;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static protected GameController s_GameInstance;
    static public GameController GameInstance { get { return s_GameInstance; } }
    static public bool isGameOver = false;

    static public bool timedGameMode = false;
    static public bool slayerGameMode = false;
    public float timeToSurvive = 90.0f; //seconds
    public int numberOfEnemiesToSlay = 10;
    public Text remainingEnemiesText;
    public Text remainingTimeText;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public CanvasGroup ThankYouImageCanvasGroup;

    float m_Timer;
    static int enemiesRemaining;
    static float timeRemaining;

    void Start()
    {
        s_GameInstance = this;
        if (slayerGameMode)
        {
            enemiesRemaining = numberOfEnemiesToSlay;

            remainingEnemiesText.text = "Enemies Remaining: " + enemiesRemaining;
            remainingEnemiesText.gameObject.SetActive(true);
        }
        else if (timedGameMode)
        {
            timeRemaining = timeToSurvive;
            remainingTimeText.text = "Time Remaining: " + (int)timeRemaining + "s";
            remainingTimeText.gameObject.SetActive(true);
        }

        isGameOver = false;
    }

    void Update()
    {
        if(slayerGameMode)
        {
            remainingEnemiesText.text = "Enemies Remaining: " + enemiesRemaining;
            if (enemiesRemaining <= 0)
            {
                isGameOver = true;
                EndLevel();
            }
        }
        else if(timedGameMode)
        {
            remainingTimeText.text = "Time Remaining: " + (int)timeRemaining + "s";
            if (timeRemaining <= 0.0f)
            {
                isGameOver = true;
                EndLevel();
            }
            else
            {
                timeRemaining = timeRemaining - Time.deltaTime;
            }
        }

        if (isGameOver)
            EndLevel();
    }

    static public void EnemySlayed()
    {
        enemiesRemaining--;
    }

    static public void ResetGame()
    {
        SceneManager.LoadScene("BLTPrototype"); // Once complete, this should return to the title screen
    }

    static public void SelectSlayerMode()
    {
        slayerGameMode = true;
    }

    static public void SelectSurvivalMode()
    {
        timedGameMode = true;
    }

    void EndLevel()
    {
        PlayerInput.Instance.ReleaseControl(true);
        m_Timer += Time.deltaTime;

        ThankYouImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }


}
