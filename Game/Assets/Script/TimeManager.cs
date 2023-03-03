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

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        limitTime -= Time.deltaTime;
        GameManager.instance.CountTime(limitTime);

        currentTime += Time.deltaTime;
        gameRound = GetGameRound(currentTime);
    }

    private void ResetTime()
    {
        limitTime = 100;
        currentTime = 0;
    }

    private int GetGameRound(float currentTime)
    {
        if (currentTime <= 30)
            return 1;

        if (currentTime <= 60)
            return 2;
        
        if (currentTime <= 100)
            return 3;

        TimeOver();
        return 0;
    }

    private void TimeOver()
    {
        GameManager.instance.OnGameOver();
        ResetTime();
    }

}
