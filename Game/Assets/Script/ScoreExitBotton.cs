using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreExitBotton : MonoBehaviour
{
    [SerializeField]
    public GameObject scoreBoard;

    public void OnClick()
    {
        scoreBoard.SetActive(false);
    }
}
