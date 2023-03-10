using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float limitTime;
    private float currentTime;
    public int gameRound;

    void Start()
    {
        ResetTime();
    }

    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        UpdateTime();
    }

    private void UpdateTime()
    {
        limitTime -= Time.deltaTime;
        GameManager.instance.CountTimer(limitTime);

        currentTime += Time.deltaTime;
        // gameRound = GetGameRound(currentTime);

        
        if (currentTime >= 100)
        {
            TimeOver();
        }
    }

    private void ResetTime()
    {
        limitTime = 100;
        currentTime = 0;
    }

    // private int GetGameRound(float currentTime)
    // {
    //     if (currentTime <= 30)
    //         return 1;

    //     if (currentTime <= 60)
    //         return 2;
        
    //     if (currentTime <= 100)
    //         return 3;

    //     TimeOver();
    //     return 0;
    // }

    private void TimeOver()
    {
        GameManager.instance.OnGameOver();
        ResetTime();
    }

}
