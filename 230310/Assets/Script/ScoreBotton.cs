using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBotton : MonoBehaviour
{
    [SerializeField]
    private Text first;
    [SerializeField]
    private Text second;
    [SerializeField]
    private Text third;

    [SerializeField]
    private GameObject scoreBoard;

    private void Start()
    {
        int firstScore = PlayerPrefs.GetInt("FirstScore");
        int secondScore = PlayerPrefs.GetInt("SecondScore");
        int thirdScore = PlayerPrefs.GetInt("ThirdScore");

        first.text = "" + firstScore;
        second.text = "" + secondScore;
        third.text = "" + thirdScore;
    }
    
    public void OnClick()
    {
        scoreBoard.SetActive(true);
    }
}
