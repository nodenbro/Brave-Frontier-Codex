using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[System.Serializable]
public class dungeons_list
{ 
    public string dungeonName;
    public string dungeonDescription;
    
}

[CreateAssetMenu(fileName = "DungeonData", menuName = "Scriptable Object/Dungeon Data")]
public class DungeonData : ScriptableObject
{
    public string dungeonID;
    public string areaName;
    public string backgroundName;

    public List<dungeons_list> dungeons = new List<dungeons_list>();

    public void PrintDungeonData()
    {
        foreach (dungeons_list dungeon in dungeons)
        {
            Debug.Log("Dungeon Name: " + dungeon.dungeonName);
            Debug.Log("Dungeon Description: " + dungeon.dungeonDescription);
        }
    }
}
