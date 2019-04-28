using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    public int playerPowerLevel;
    public TextMeshProUGUI powerText; // @TODO need to move outside
    public Slider powerLevelSlider;

    private void Start()
    {
        powerLevelSlider.value = PlayerPowerLevel;
    }

    public int PlayerPowerLevel
    {
        get
        {
            powerText.text = playerPowerLevel.ToString();
            powerLevelSlider.value = playerPowerLevel;

            return playerPowerLevel;
        }
        set
        {
            playerPowerLevel = value;
            
            powerText.text = playerPowerLevel.ToString();
            powerLevelSlider.value = playerPowerLevel;

        }
        
    }
}