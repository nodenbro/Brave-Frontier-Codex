using UnityEngine;

public class DialogueButtonRotationEffect : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float rotationSpeed = 95f;
    public float minAlpha = 0.6f;
    public float maxAlpha = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.transform.Rotate(0f, 0f, - rotationSpeed * Time.deltaTime);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.PingPong(Time.time * -1, maxAlpha - minAlpha) + minAlpha);
    }
}
