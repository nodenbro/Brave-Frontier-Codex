using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class BGSManager : MonoBehaviour
{

    [SerializeField] public List<AudioClip> soundsList = new List<AudioClip>();

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBGS(int index)
    {
        if (audioSource != null && soundsList != null && index >= 0 && index < soundsList.Count)
        {
            audioSource.clip = soundsList[index];
            audioSource.Play();
            Debug.Log("Playing BGS: " + soundsList[index].name);
        }
    }
}
