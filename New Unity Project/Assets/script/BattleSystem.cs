using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //public GameObject playerPrefab;
    //public GameObject enemyPrefab;
    public static BattleSystem instance;
    void Awake()
    {
        instance = this;
    }
    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }
    void SetupBattle() 
    {
        state = BattleState.PLAYERTURN;
        PlayerTurn();
        //PlayerTurn();
    }
    void PlayerTurn() 
    {
        if (GameManager.instance.battleHasEnded && GameManager.instance.battleWon)
        {
            state = BattleState.ENEMYTURN;
        }
    }
   
}
