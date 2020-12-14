using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;

public class GodMode: MonoBehaviour {  
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (Input.GetKeyDown(KeyCode.Alpha1) && sceneName != "Level1Scene") SceneManager.LoadScene("Level1Scene");
        else if (Input.GetKeyDown(KeyCode.Alpha2) && sceneName != "Level2Scene") SceneManager.LoadScene("Level2Scene");
        else if (Input.GetKeyDown(KeyCode.Alpha3) && sceneName != "Level3Scene") SceneManager.LoadScene("Level3Scene");
        else if (Input.GetKeyDown(KeyCode.Alpha4) && sceneName != "Level4Scene") SceneManager.LoadScene("Level4Scene");
        else if (Input.GetKeyDown(KeyCode.Alpha5) && sceneName != "Level5Scene") SceneManager.LoadScene("Level5Scene");
    }
}   