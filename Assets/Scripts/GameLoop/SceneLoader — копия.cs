using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    public static void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 31) SceneManager.LoadScene(10);
        else  SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
