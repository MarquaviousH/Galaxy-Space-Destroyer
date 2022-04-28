using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuHandler : MonoBehaviour
{
    //Load the main game scene
    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }

    //Load the main menu scene
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Exit out of play mode or application
    public void Exit()
    {
        GameManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
