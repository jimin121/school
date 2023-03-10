using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyBotton : MonoBehaviour
{
    public void OnClick()
    {
         SceneManager.LoadScene("Lobby");
    }
}