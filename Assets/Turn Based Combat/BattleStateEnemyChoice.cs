using UnityEngine;
using System.Collections;

public class BattleStateEnemyChoice{

	public void EnemyAction(BaseCharacterClass Enemy1,BaseCharacterClass Enemy2)
    {
        //who are we using for battle 1
        Debug.Log(Enemy1.CharacterClassName + " is about to attack.");
        Debug.Log(Enemy2.CharacterClassName + " is about to attack.");

        //ability
        if (Enemy1.Health>0)
        {
            ChooseMeleeEnemyAbility(Enemy1);
           // Debug.Log(Enemy1.ability2.abilityName);
        }
        if (Enemy2.Health > 0)
        {
            ChooseMeleeEnemyAbility(Enemy2);
        }
        //damage
        //end
        if(Enemy1.Health + Enemy2.Health == 0)
        {
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.WIN;
        }
    }
    private void EnemyAction(BaseCharacterClass Enemy1, BaseCharacterClass Enemy2, BaseCharacterClass Enemy3)
    {
        //ability
        //damage
        //end
    }
    private BaseAbility ChooseMeleeEnemyAbility(BaseCharacterClass enemy)
    {
        return enemy.ability1;
    }
    private BaseAbility ChooseHealerEnemyAbility(BaseCharacterClass enemy)
    {
        return enemy.ability2;
    }
}
