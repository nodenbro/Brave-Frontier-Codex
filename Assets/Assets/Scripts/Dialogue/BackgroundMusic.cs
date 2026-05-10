using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    #region Public Variables
    public AudioSource audio;
    public bool IsLoop = true;
    public float volume = 0.2f;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(audio != null)
        {
            audio.Play();
            audio.loop = IsLoop;
            audio.volume = volume;
        }
        else
        {
            Debug.LogError("AudioSource is missing, put one, dumbass");
        }
    }

    // Update is called once per frame
    void Update()
    {
        audio.loop = IsLoop;
        audio.volume = volume;
    }
}
