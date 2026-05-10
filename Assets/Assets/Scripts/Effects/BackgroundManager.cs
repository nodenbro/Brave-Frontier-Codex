using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public List<Sprite> bgsList = new List<Sprite>();
    [SerializeField] public List<Sprite> dialogue_bg_list = new List<Sprite>();

    public Image mainBG;
    public Image tempBG;
    //string bgname = "dungeon_battle_0001";

    public void ChangeBackground(int index)
    { 
        mainBG.sprite = bgsList[index];
    }

    public void DialogueBackground(DungeonData dungeon)
    {
        tempBG.sprite = dialogue_bg_list.Find(bg => bg.name == dungeon.backgroundName);
        Debug.Log("Background found: " + dungeon.backgroundName);
        Debug.Log("Scene is : " + dungeon.dungeons[0].dungeonName);
    }

    public void StartFading()
    {
        mainBG.color = new Color32(93, 93, 93, 255);
    }

    public void OriginalColor()
    {
        mainBG.color = new Color32(255, 255, 255, 255);
    }
}
