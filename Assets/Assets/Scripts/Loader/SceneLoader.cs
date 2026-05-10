using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string sceneName;
    public float loadTime = 4f;

    public void changeScene(string newSceneName)
    {
        sceneName = newSceneName;
        SceneManager.LoadScene("Loading_Scene", LoadSceneMode.Additive);
        StartCoroutine(LoadSceneDelay());
    }

    IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(sceneName);
    }
}
