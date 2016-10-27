using UnityEngine;
using System.Collections;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    private BattleCalculations battleCalcScript = new BattleCalculations();
    private BattleStateEnemyChoice enemyChoiceScript = new BattleStateEnemyChoice();
    public BattleStateStart battleStateStartScript = new BattleStateStart();  
    public static PlayerParty playerParty = new PlayerParty();    
    public static BaseAbility[] usedAbilities = new BaseAbility[3];
    public static int turnCount;

    public static BattleStates currentState;
    private BattleNumber currentBattleNumber;
    
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        PLAYERANIMATE,
        ENEMYCHOICE,
        CALCDAMAGE,
        ENDTURN,
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
        turnCount = 1;
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
                enemyChoiceScript.EnemyAction(BattleStateStart.);
                break;
            case (BattleStates.CALCDAMAGE):
                battleCalcScript.CalculatePlayerForTurn(usedAbilities[0], usedAbilities[1], usedAbilities[2]);
            break;
            case (BattleStates.ENDTURN):
                turnCount++;
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
