using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionManager : MonoBehaviour
{
    int originalWidth;
    int originalHeight;
    bool originalFullscreen;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        originalWidth = Screen.width;
        originalHeight = Screen.height;
        originalFullscreen = Screen.fullScreen;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title_Screen")
        {
            Screen.SetResolution(640, 1136, false);
        }
        else
        {
            Screen.SetResolution(originalWidth, originalHeight, originalFullscreen);
        }
    }
}