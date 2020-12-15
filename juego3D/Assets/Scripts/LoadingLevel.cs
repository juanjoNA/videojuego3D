using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        levelToLoad = SceneLoader.nextLevel;

        StartCoroutine(Load(levelToLoad));
    }

    IEnumerator Load(string level)
    {
        yield return new WaitForSeconds(2f);

        AsyncOperation op = SceneManager.LoadSceneAsync(level);

        while (!op.isDone)
        {
            yield return null;
        }
    }
}
