using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberSpriteLoader : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_Text name, arenaRank, gems, karma, zel, level, rcRank, energy;

    public void Start()
    {
        name.text = playerData.playerName;
        arenaRank.text = playerData.playerArenaRank;
        gems.text = ConvertToSpriteText(playerData.playerGems);
        karma.text = ConvertToSpriteText(playerData.playerKarma);
        zel.text = ConvertToSpriteText(playerData.playerZel);
        level.text = ConvertToSpriteText(playerData.playerLevel);
        rcRank.text = ConvertToSpriteText(playerData.playerRCRank);
        energy.text = UpdateEnergy(playerData.playerEnergyLeft, playerData.playerEnergyMax);

    }

    public string ConvertToSpriteText(int number)
    {
        string result = "";
        foreach (char c in number.ToString())
        {
            result += $"<sprite=" + c + ">";
        }
        return result;
    }

    public string UpdateEnergy(int energy_left, int energy_max)
    {
        string result = "";

        foreach (char l in energy_left.ToString())
        {
            result += $"<sprite=" + l + ">";
        }

        result += $"<sprite=" + 11 +">";

        foreach (char m in energy_max.ToString())
        {
            result += $"<sprite=" + m + ">";
        }
        return result;
    }
}
