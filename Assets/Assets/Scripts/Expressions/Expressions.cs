using UnityEngine;

public class Expressions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer spriteRenderer;

    public Sprite neutralFace;
    public Sprite confusedFace;
    public Sprite smilingFace;
    public Sprite angryFace;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = neutralFace;
    }

    public void SetExpression(string expression)
    {
        switch(expression.ToLower())
        {
            case "neutral":
                spriteRenderer.sprite = neutralFace;
                break;
            case "confused":
                spriteRenderer.sprite = confusedFace;
                break;
            case "smiling":
                spriteRenderer.sprite = smilingFace;
                break;
            case "angry":
                spriteRenderer.sprite = angryFace;
                break;
            default:
                spriteRenderer.sprite = neutralFace;
                break;
        }
    }

    void Update()
    {
        // Example of using Expression changing

        if (Input.GetKeyDown(KeyCode.Space))
            SetExpression("smiling");

        if (Input.GetKeyDown(KeyCode.A))
            SetExpression("angry");

        if (Input.GetKeyDown(KeyCode.C))
            SetExpression("confused");
    }
}
