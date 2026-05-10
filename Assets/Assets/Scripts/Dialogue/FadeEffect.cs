using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    public Image characterImage;
    public float duration = 1f;

    public IEnumerator FadeIn()
    {
        Color color = characterImage.color;
        float startAlpha = 0f;
        float time = Time.deltaTime;

        color.a = 0f;
        characterImage.color = color;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 1.5f, fadeSpeed * time * 1.5f);
            color.a = alpha;
            characterImage.color = color;

            yield return null;
        }
    }

}


