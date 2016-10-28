using UnityEngine;
using System.Collections;

public class BattleStateEnemyChoice{

	public void EnemyAction(BaseCharacterClass Enemy1,BaseCharacterClass Enemy2)
    {
        //who are we using for battle 1
        Debug.Log(Enemy1.CharacterClassName + " is about to attack.");
        //Debug.Log(Enemy2.CharacterClassName + " is about to attack.");

        //use ability also check for death
        if (Enemy1.Health > 0)
        {
            UseMeleeEnemyAbility(Enemy1);
           // Debug.Log(Enemy1.ability2.abilityName);
        }
        if (Enemy2.Health > 0)
        {
            UseMeleeEnemyAbility(Enemy2);
        }
        //check for win
        if (Enemy1.Health <= 0f && Enemy2.Health <= 0f)
        {
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.WIN;
        }else if (PlayerParty.Warrior.Health <= 0f && PlayerParty.Mage.Health <= 0f && PlayerParty.Healer.Health <= 0f)
        {
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.LOSE;
        }
        else
        {
            //change state
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENDTURN;
        }
    }
    //battle 2
    private void EnemyAction(BaseCharacterClass Enemy1, BaseCharacterClass Enemy2, BaseCharacterClass Enemy3)
    {
        //ability
        //damage
        //end
    }
    private void UseMeleeEnemyAbility(BaseCharacterClass enemy)
    {
        //uses swipe
        PlayerParty.Warrior.Health -= ((enemy.Attack*enemy.ability2.multiplier) - PlayerParty.Warrior.Defense);
        PlayerParty.Mage.Health -= ((enemy.Attack * enemy.ability2.multiplier) - PlayerParty.Mage.Defense);
        PlayerParty.Healer.Health -= ((enemy.Attack * enemy.ability2.multiplier) - PlayerParty.Healer.Defense);

    }
    private BaseAbility ChooseHealerEnemyAbility(BaseCharacterClass enemy)
    {
        return enemy.ability2;
    }
}
