using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFadeOut : MonoBehaviour
{
    public static string scene_name;
    public float fadeSpeed = 1f;

    public Animator transition;


    public void changeScene(string newSceneName)
    {
        //tempPrefabObject = Instantiate(loaderPrefab);
        scene_name = newSceneName;
        StartCoroutine(FadeEffectDelay());
    }

    IEnumerator FadeEffectDelay()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(fadeSpeed);
        SceneManager.LoadScene(scene_name);

        Debug.Log("The scene name from the IEnumerator is: " + scene_name);
    }
}
