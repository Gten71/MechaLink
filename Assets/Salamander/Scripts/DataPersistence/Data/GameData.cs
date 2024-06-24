using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public Vector3 playerPosition;
    public int fireSoulsForSave;
    public int waterSoulsForSave;
    public int airSoulsForSave;
    public int generalSoulsForSave;

    public GameData() 
    {
        playerPosition = Vector3.zero;
        fireSoulsForSave = 0;
        waterSoulsForSave = 0;
        airSoulsForSave = 0;
        generalSoulsForSave = 0;
    }

    //public int GetPercentageComplete() 
    //{
    //    return percentageCompleted;
    //}
}
