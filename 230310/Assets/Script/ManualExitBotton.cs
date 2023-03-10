using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualExitBotton : MonoBehaviour
{
    [SerializeField]
    public GameObject manualBoard;

    public void OnClick()
    {
        manualBoard.SetActive(false);
    }
}
