using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerAccountData playerAccountData;
    //public string playerID;

    public GameData()
    {
        //this.playerID = "defval";
       this.playerAccountData = new PlayerAccountData();
    }
}
