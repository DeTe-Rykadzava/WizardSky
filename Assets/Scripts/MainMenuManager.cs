using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        Debug.Log("Exit");
        return;
#endif
        Environment.Exit(0);
    }
}
