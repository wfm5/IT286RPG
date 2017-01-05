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
        CheckHealth(); //cannot let hp go over max
        //Debug.Log(currentBattleNumber);
        if (Input.GetKey("escape"))
            Application.Quit();
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
                break;
            case (BattleStates.ENEMYCHOICE):
                if(currentBattleNumber == BattleNumber.ONE)
                    battleStateStartScript.enemyChoiceScript.EnemyAction(BattleStateStart.Enemy1, BattleStateStart.Enemy2);
                break;
            case (BattleStates.CALCDAMAGE):
                //playerdamage
                battleCalcScript.CalculatePlayerForTurn(usedAbilities[0], usedAbilities[1], usedAbilities[2]);
                //enemy damage
                break;
            case (BattleStates.ENDTURN):
                //count buffs
                turnCount++;
                PlayerParty.Warrior.CurrentTech += 10;
                CheckBuffs();
                currentState = BattleStates.PLAYERCHOICE;
                break;
            case (BattleStates.LOSE):
                Debug.Log("You lose.....");
                break;
            case (BattleStates.WIN):
                Debug.Log("You won.....");
                break;
        }
	}
    private void CheckHealth()
    {        
        //replace with for loops....
        if (PlayerParty.Warrior.Health > PlayerParty.Warrior.MaxHealth)
            PlayerParty.Warrior.Health = PlayerParty.Warrior.MaxHealth;
        if (PlayerParty.Mage.Health > PlayerParty.Mage.MaxHealth)
            PlayerParty.Mage.Health = PlayerParty.Mage.MaxHealth;
        if (PlayerParty.Healer.Health > PlayerParty.Healer.MaxHealth)
            PlayerParty.Healer.Health = PlayerParty.Healer.MaxHealth;
        if (PlayerParty.Healer.CurrentMana > PlayerParty.Healer.MaxMana)
            PlayerParty.Healer.CurrentMana = PlayerParty.Healer.MaxMana;
        if (PlayerParty.Warrior.CurrentTech > PlayerParty.Warrior.MaxTech)
            PlayerParty.Warrior.CurrentTech = PlayerParty.Warrior.MaxTech;
        
        if (PlayerParty.Warrior.Health < 0f)
            PlayerParty.Warrior.Health = 0f;
        if (PlayerParty.Mage.Health < 0f)
            PlayerParty.Mage.Health = 0f;
        if (PlayerParty.Healer.Health < 0f)
            PlayerParty.Healer.Health = 0f;
        if (PlayerParty.Warrior.CurrentTech < 0f)
            PlayerParty.Warrior.CurrentTech = 0f;

        if (BattleStateStart.Enemy1.Health > BattleStateStart.Enemy1.MaxHealth)
            BattleStateStart.Enemy1.Health = BattleStateStart.Enemy1.MaxHealth;
        if (BattleStateStart.Enemy2.Health > BattleStateStart.Enemy2.MaxHealth)
            BattleStateStart.Enemy2.Health = BattleStateStart.Enemy2.MaxHealth;
        if (BattleStateStart.Enemy3.Health > BattleStateStart.Enemy3.MaxHealth)
            BattleStateStart.Enemy3.Health = BattleStateStart.Enemy3.MaxHealth;

        if (BattleStateStart.Enemy1.Health < 0f)
            BattleStateStart.Enemy1.Health = 0f;
        if (BattleStateStart.Enemy2.Health < 0f)
            BattleStateStart.Enemy2.Health = 0f;
        if (BattleStateStart.Enemy3.Health < 0f)
            BattleStateStart.Enemy3.Health = 0f;


    }
    private void CheckBuffs()
    {
        //decrement buffs
        if (PlayerParty.Warrior.Buffed > 0) //Doping counter
            PlayerParty.Warrior.Buffed--;
        //DivineLight counters
        if (PlayerParty.Warrior.BuffedH > 0)
            PlayerParty.Warrior.BuffedH--;

        if (PlayerParty.Mage.BuffedH > 0)
            PlayerParty.Mage.BuffedH--;

        if (PlayerParty.Healer.BuffedH > 0)
            PlayerParty.Healer.BuffedH--;
        //if 0 take em off
        if (PlayerParty.Warrior.Buffed == 0) //doping off
            Doping.RemoveDoping(PlayerParty.Warrior);

        if (PlayerParty.Warrior.BuffedH == 0) //all divine lights come off together
            DivineLight.RemoveDivineLight(PlayerParty.Warrior, PlayerParty.Mage, PlayerParty.Healer);
    }    
}
