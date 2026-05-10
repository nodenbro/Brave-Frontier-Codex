using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


[System.Serializable]
public class DialogueLine
{
    public int id;
    public RectTransform charPos;
    public string speakerName;
    [TextArea(2, 5)]
    public string dialogueText;
    public string expressionPath;
    public Sprite expressionSprite;
}
[System.Serializable]
public class Dungeon
{
    public string dungeonID;
    public string dungeonName;
    public string dungeonDescription;
    public DialogueLine[] dialogueLines;
}

[System.Serializable]
public class DungeonDatabase
{
    public Dungeon[] dungeons;
}

public static class DialogueParser
{
    public static string Parse(string text, PlayerData playerData)
    {
        return Regex.Replace(text, @"\{\{\s*(.*?)\s*\}\}", match =>
        {
            string key = match.Groups[1].Value.Trim();

            if (key == "user")
                return playerData.playerName;

            return match.Value;
        });
    }
}

public class Dialogue : MonoBehaviour
{
    // Reference to the text file containing the dialogue lines
    public TextAsset dialogueJSON; 

    public DungeonDatabase dungeonDB;

    // Used to get the areas GameObejct so they can be enabled on dialogue end
    public GameObject areas;

    // References the gameobject that overlays the background during dialogue and the original background object
    public GameObject temp_dialogue_bg, original_bg;

    // Reference to the charPos ScriptableObject to access character positions
    public charPos charPosSO;

    // Reference to the PlayerData ScriptableObject to access player information for dynamic text replacement
    public PlayerData playerData;

    public FadeEffect fadeIn;

    public int charID;
    public Image characterImage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public UIManager prefabClear;


    // Reference to the button wait object
    public GameObject buttonWaitObject;

    // Reference to the button wait object's RectTransform
    public RectTransform buttonWaitRect; 
    private Vector2 localPos;

    public float delay = 0.1f;
    public string fullText;
    bool effectSkipped = false;
    float lastClick = -999f;
    public float click_cooldown = 0.3f;

    // Variable used to store the dungeon ID based on the DungeonData passed to the LoadDialogue method
    public string dID; 

    public int currentLine = 0;

    void Start()
    {
        //ShowLine(currentLine, dID);

        // Ensure the button wait object is initially inactive
        buttonWaitObject.SetActive(false); 
    }

    void Update()
    {
        if(dialogueText.text == fullText)
        {
            // Show the button wait object when the full text is displayed
            buttonWaitObject.SetActive(true); 
        }


        if (Input.GetMouseButtonDown(0))
        { 
            if (!effectSkipped)
            {
                StopAllCoroutines();
                dialogueText.text = fullText;
                effectSkipped = true;
                return; 
            }

            if (Time.time > lastClick + click_cooldown)
            {
                lastClick = Time.time;
                NextLine();
            }
        }

        // The Method gets the position of the last line of the Text and moves the Y position of the button dynamically.

        ButtonWaitPos();
    }

    // Loads the dialogue for the specified dungeon ID and initializes the dialogue display
    public void LoadDialogue(DungeonData dungeon)
    {
        dID = dungeon.dungeonID;
        currentLine = 0;
        ShowLine(currentLine, dID);
        fadeIn.StartCoroutine(fadeIn.FadeIn());

    }

    public void ShowLine(int index, string dID)
    {              
        dungeonDB = JsonUtility.FromJson<DungeonDatabase>(dialogueJSON.text);

        Dungeon currentDungeon = System.Array.Find(
        dungeonDB.dungeons,
        d => d.dungeonID == dID);

        if (currentDungeon != null && index < currentDungeon.dialogueLines.Length)
            {
            // Parse the dialogue text to replace dynamic placeholders for {{user}}
            string parsedText = DialogueParser.Parse(currentDungeon.dialogueLines[index].dialogueText, playerData); 
            fullText = parsedText;
            DialogueLine line = currentDungeon.dialogueLines[index];

            // Load the sprite from the specified path in the JSON
            line.expressionSprite = Resources.Load<Sprite>(line.expressionPath); 

                charID = line.id;
                nameText.text = line.speakerName;

                characterImage.sprite = line.expressionSprite;
                characterImage.SetNativeSize();

                // Uses the character ID to get the position from the charPos ScriptableObject
                characterImage.rectTransform.anchoredPosition = charPosSO.GetCharPos(charID); 

                StopAllCoroutines();

                StartCoroutine(ShowText());     
            }
            else
            {
                gameObject.SetActive(false);

                // Enable the areas GameObject when the dialogue ends
                areas.SetActive(true);

                // Disable the temporary dialogue background overlay when the dialogue ends
                temp_dialogue_bg.SetActive(false);

                // Re-enable the original background when the dialogue ends
                original_bg.SetActive(true);

                prefabClear.UnloadAreaInfo();
        }
        //}
    }

    //Coroutine to display text one character at a time and removes the tag display from the effect
    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {

            dialogueText.text = fullText.Substring(0, i);

            if (i >= fullText.Length)
                break;

            // If tag starts, skip it instantly
            if (fullText[i] == '<')
            {
                int closingIndex = fullText.IndexOf('>', i);
                if (closingIndex != -1)
                {
                    dialogueText.text += fullText.Substring(i, closingIndex - i + 1);
                    i = closingIndex + 1;
                    continue;
                }
            }

            yield return new WaitForSeconds(delay);
        }
    }

    void NextLine()
    {
        effectSkipped = false;
        currentLine++;
        ShowLine(currentLine, dID);

        // Hide the button wait object when moving to the next line
        buttonWaitObject.SetActive(false); 
    }

    // Method to position the button wait object dynamically based on the last line of the dialogue text
    void ButtonWaitPos()
    {
        dialogueText.ForceMeshUpdate();


        if (dialogueText.textInfo.lineCount == 0)
        {
            Debug.LogWarning("No lines in text yet");
            return;
        }

        TMP_LineInfo lastLine = dialogueText.textInfo.lineInfo[dialogueText.textInfo.lineCount - 1];

        float xCenter = (lastLine.lineExtents.min.x + lastLine.lineExtents.max.x) / 2f;
        float y = lastLine.baseline - 45;

        Vector2 localPos = new Vector2(xCenter, y);

        // Position the button wait object below the character
        buttonWaitRect.anchoredPosition = new Vector2(buttonWaitRect.anchoredPosition.x, localPos.y); 
    }

}
