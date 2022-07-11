using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAccountData
{
    public string playerName;
    public string playerID;
    public bool isVIP;

    public PlayerAccountData()
    {
        playerName = "player";
        playerID = "StartID";
        isVIP = true;
    }
}
