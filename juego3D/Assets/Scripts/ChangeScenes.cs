using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    private bool loadPage = false;
    public void cargarEscena(string scene)
    {
        Debug.Log("ENTRO EN SCENE MANAGER");
        SceneManager.LoadScene(1);
    }
    public void loadSceneWithLoadPage(string scene)
    {
        loadPage = true;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(scene);
        /**
         * Cargamos la escena de manera asincrona y asi le damos tiempo a cargarse totalmente
         * SceneManager.LoadSceneAsync(scene);
         * Ejemplos:
         * https://gamedevbeginner.com/how-to-load-a-new-scene-in-unity-with-a-loading-screen/
         */

    }
}
