using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBotton : MonoBehaviour
{
    public GameObject manualUI;

    public void OnClick()
    {
        manualUI.SetActive(true);
    }
}
