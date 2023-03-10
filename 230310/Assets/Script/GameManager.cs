using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public bool isPressed_restartBotton = false;

    public Text timerText;
    public Text scoreText;
    public GameObject gameoverUI;
    public Text highScoreText;

    private int[] recordScore = new int[3];

    private int currentScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isGameover && isPressed_restartBotton)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        currentScore += newScore;
        scoreText.text = "Score : " + currentScore;
    }

    public void CountTimer(float limitTime)
    {
        float currentLimitTime = Mathf.Ceil(limitTime);
        timerText.text = "" + currentLimitTime;
    }

    public void OnGameOver()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
        
        recordScore[0] = PlayerPrefs.GetInt("FirstScore");
        recordScore[1] = PlayerPrefs.GetInt("SecondScore");
        recordScore[2] = PlayerPrefs.GetInt("ThirdScore");

        if (recordScore[0] < currentScore)
        {
            recordScore[2] = recordScore[1];
            recordScore[1] = recordScore[0];
            recordScore[0] = currentScore;
        }
        else if (recordScore[1] < currentScore)
        {
            recordScore[2] = recordScore[1];
            recordScore[1] = currentScore;
        }
        else if (recordScore[2] < currentScore)
        {
            recordScore[2] = currentScore;
        }

        PlayerPrefs.SetInt("FirstScore", recordScore[0]);
        PlayerPrefs.SetInt("SecondScore", recordScore[1]);
        PlayerPrefs.SetInt("ThirdScore", recordScore[2]);

        highScoreText.text = "" + recordScore[0];

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GetBottonInput()
    {
        isPressed_restartBotton = true;
    }
}