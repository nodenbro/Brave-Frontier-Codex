using UnityEngine;
using System.Collections.Generic;

public class DungeonLoader : MonoBehaviour
{
    public TextAsset jsonFile;

    public Dialogue Dungeon = new Dialogue();

    private Dictionary<string, Dungeon> dungeonDict;

    void Awake()
    {
        var database = JsonUtility.FromJson<DungeonDatabase>(jsonFile.text);

        dungeonDict = new Dictionary<string, Dungeon>();

        foreach (var dungeon in database.dungeons)
        {
            dungeonDict[dungeon.dungeonID] = dungeon;
        }
    }

    public Dungeon GetDungeon(string id)
    {
        dungeonDict.TryGetValue(id, out var dungeon);
        return dungeon;
    }
}
