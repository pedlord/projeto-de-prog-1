using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Country
{
    public string name;
    public enum theTribes
    { 
        GANGS,
        BADS,
        NORDS,
        HUNTERS,
        PLAYER
    }
    public theTribes tribe;

    public int moneyReward;
    public int expReward;
}
