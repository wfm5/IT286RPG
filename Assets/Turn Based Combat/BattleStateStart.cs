using UnityEngine;
using System.Collections;

public class BattleStateStart
{
    //object needed for stat calc
    BaseCharacterClass Enemy1 = new BaseCharacterClass();
    BaseCharacterClass Enemy2 = new BaseCharacterClass();
    BaseCharacterClass Enemy3 = new BaseCharacterClass();

    private int WarriorHealth;
    private int WarriorTch;
    private int MageHealth;
    private int MageMana;
    private int HealerHealth;
    private int HealerMana;
    //Prepare Battle functions
    public void PrepareBattle1()
    {
        //create enemy
        Enemy1 = CreateMeleeEnemy();
        Enemy2 = CreateMeleeEnemy();
        //apply buffs or specs here
        Enemy1.CharacterClassName = "Swiper1";
        Enemy2.CharacterClassName = "Swiper2";
        //Who's turn?
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;

    }
    public void PrepareBattle2()
    {
        TurnBasedCombatStateMachine.turnCount = 1;
        //create enemy
        Enemy1 = CreateMeleeEnemy();
        Enemy2 = CreateMageEnemy();
        //apply buffs or specs here
        
        //Who's turn?
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;

    }
    public void PrepareBattle3()
    {
        TurnBasedCombatStateMachine.turnCount = 1;
        //create enemy
        Enemy1 = CreateMeleeEnemy();
        Enemy2 = CreateHealerEnemy();
        Enemy3 = CreateHealerEnemy();
        //apply buffs or specs here
        
        //Who's turn?
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;

    }

    //creation functions
    private BaseMeleeClass CreateMeleeEnemy()
    {
        BaseMeleeClass newEnemy = new BaseMeleeClass();
        return newEnemy;
    }
    private BaseMageClass CreateMageEnemy()
    {
        BaseMageClass newEnemy = new BaseMageClass();
        return newEnemy;
    }
    private BaseHealerClass CreateHealerEnemy()
    {
        BaseHealerClass newEnemy = new BaseHealerClass();
        return newEnemy;
    }
    //Stat functions feed vitals to game
    private void PlayerStatus()
    {
        //do i need this?
        //PlayerParty.Warrior.Health;
    }
}