using UnityEngine;
using System.Collections;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public BattleStateStart battleStateStartScript = new BattleStateStart();
    private StatCalc statCalcScript = new StatCalc();

    public static BattleStates currentState;
    private BattleNumber currentBattleNumber;
    
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        PLAYERANIMATE,
        ENEMYCHOICE,
        CALCDAMAGE,
        LOSE,
        WIN
    }
    public enum BattleNumber
    {
        ONE,
        TWO,
        THREE
    }

	// Use this for initialization
	void Start () {
        currentState = BattleStates.START;
        currentBattleNumber = BattleNumber.ONE;
	}

	void Update () {
        
        Debug.Log(currentState);
        //Debug.Log(currentBattleNumber);
        switch (currentState)
        {
            case (BattleStates.START) :
                //SETUP BATTLE FUNCTIONS
                if(currentBattleNumber == BattleNumber.ONE)
                    battleStateStartScript.PrepareBattle1();
                else if(currentBattleNumber == BattleNumber.TWO)
                    battleStateStartScript.PrepareBattle2();
                else if(currentBattleNumber == BattleNumber.THREE)
                    battleStateStartScript.PrepareBattle3();
                break;
            case (BattleStates.PLAYERCHOICE):
                //Debug.Log()
                
                break;
            case (BattleStates.ENEMYCHOICE):
                break;
            case (BattleStates.CALCDAMAGE):
                
            break;
            case (BattleStates.LOSE):
                break;
            case (BattleStates.WIN):
                break;
        }
	}

    void OnGUI()
    {
        //Debug.Log("uhhhhh");
        if (GUILayout.Button("NEXT STATE"))
        {
            if (currentState == BattleStates.START)
                currentState = BattleStates.PLAYERCHOICE;
        }
    }
}
