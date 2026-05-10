using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Object/Player Data")]
public class PlayerData: ScriptableObject
{
    public string playerName, playerArenaRank;
    public int playerLevel, playerRCRank, playerGems, playerZel, playerKarma, playerEnergyLeft, playerEnergyMax;
}
