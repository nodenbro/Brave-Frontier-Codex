using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public PlayerData player;
    private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = player.playerEnergyMax;
        slider.value = player.playerEnergyLeft;
    }
}
