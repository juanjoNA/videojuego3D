using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public static class SceneLoader
{
    public static string nextLevel;

    public static void loadScene(string sceneName)
    {
        nextLevel = sceneName;

        string loadPage = "Loading"+sceneName.Substring(sceneName.Length - 1);
        SceneManager.LoadScene(loadPage);
    }
}
