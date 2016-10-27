using UnityEngine;
using System.Collections;
//Hub for all battle applications
//state declarations are here
public class TurnBasedCombatStateMachine : MonoBehaviour {

    private BattleCalculations battleCalcScript = new BattleCalculations();
    public BattleStateStart battleStateStartScript = new BattleStateStart();  
    public static PlayerParty playerParty = new PlayerParty();    
    public static BaseAbility[] usedAbilities = new BaseAbility[3]; //abilities loaded by player - 3 slot array but indices are 0,1,2
    public static BaseCharacterClass[] targetEnemies = new BaseCharacterClass[3]; //3 enemies targeted 0 - warrior 1 - mage 2 - healer

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
                battleStateStartScript.enemyChoiceScript.EnemyAction(BattleStateStart.Enemy1, BattleStateStart.Enemy2);
                break;
            case (BattleStates.CALCDAMAGE):
                //playerdamage
                battleCalcScript.CalculatePlayerForTurn(usedAbilities[0], usedAbilities[1], usedAbilities[2]);
                //enemy damage

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
        if (GUI.Button(new Rect(1,100, 90, 30), "NEXT STATE"))
        {
            if (currentState == BattleStates.START)
                currentState = BattleStates.PLAYERCHOICE;
        }
    }
}
