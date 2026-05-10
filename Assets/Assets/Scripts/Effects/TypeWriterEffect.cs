using UnityEngine;
using TMPro;
using System.Collections;

public class TypeWriterEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float delay = 0.1f;
    public string fullText;
    private TMP_Text textMP;
    bool effectSkipped = false;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        textMP = GetComponent<TMP_Text>();
        fullText = textMP.text;
        textMP.text = "";
        StartCoroutine(ShowText());
    }

    // Coroutine to display text one character at a time
    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textMP.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    // Update to check for mouse click to skip the effect
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && effectSkipped == false)
        {
            StopAllCoroutines();
            textMP.text = fullText;
            effectSkipped = true;
        }

    }
}
