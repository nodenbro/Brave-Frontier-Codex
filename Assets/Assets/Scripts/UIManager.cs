using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text areaName;
    public TMP_Text dName;
    public TMP_Text dDesc;

    public GameObject dungeonParent;
    public GameObject dungeonToSpawn;
    private GameObject dungeonSpawn;

    public Dialogue dungeonLoad;
    public BackgroundManager bgManager;
    public Button btn;

    public GameObject main_dungeon;
    public float offsetY = 11;

    public void LoadAreaInfo(DungeonData dungeon)
    {
        main_dungeon.transform.Find("mission_name").GetComponent<TMP_Text>().text = dungeon.dungeons[0].dungeonName;
        main_dungeon.transform.Find("mission_desc").GetComponent<TMP_Text>().text = dungeon.dungeons[0].dungeonDescription;

        // Clear exisitng listeners then add a listener to load the dialogue.
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => dungeonLoad.LoadDialogue(dungeon));
        btn.onClick.AddListener(() => bgManager.DialogueBackground(dungeon));
        //btn.Setup(dungeon);

        areaName.text = dungeon.areaName;

        Debug.Log("Dungeon Count: " + dungeon.dungeons.Count);

        for (int i = 1; i < dungeon.dungeons.Count; i++)
        {
            // Set the header text, dungeon name, and description text
            Debug.Log(dungeon == null ? "Dungeon is NULL" : dungeon.name);

            dungeonSpawn = Instantiate(dungeonToSpawn, dungeonParent.transform);
            dungeonSpawn.GetComponent<RectTransform>().anchoredPosition = new Vector2(dungeonToSpawn.GetComponent<RectTransform>().anchoredPosition.x, offsetY);
            dName = dungeonSpawn.transform.Find("mission_name").GetComponent<TMP_Text>();
            dDesc = dungeonSpawn.transform.Find("mission_desc").GetComponent<TMP_Text>();

            if (dDesc == null || dName == null)
            {
                Debug.LogError("UI element is missing!");
                return;
            }

            dName.text = dungeon.dungeons[i].dungeonName;
            dDesc.text = dungeon.dungeons[i].dungeonDescription;
            // Adjust the offset for the next dungeon entry
            offsetY -= 145f;

        }
    }

    public void UnloadAreaInfo()
    {
        dName.text = "";
        dDesc.text = "";
        foreach (Transform child in dungeonParent.transform)
        {
            if(child.name != "dungeon_frame_template")
            {
                Destroy(child.gameObject);
            }     
        }
        // Reset the offset for the next area
        offsetY = 11f;
    }

}
