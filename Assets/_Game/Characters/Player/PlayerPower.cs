using TMPro;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public int playerPowerLevel;
    public TextMeshProUGUI powerText; // @TODO need to move outside

    private void Start()
    {
        Debug.Log(PlayerPowerLevel);
    }

    public int PlayerPowerLevel
    {
        get
        {
            powerText.text = playerPowerLevel.ToString();
            return playerPowerLevel;
        }
        set
        {
            playerPowerLevel = value;
            powerText.text = playerPowerLevel.ToString();
        }
        
    }
}