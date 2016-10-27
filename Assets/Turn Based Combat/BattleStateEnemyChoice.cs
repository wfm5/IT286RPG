using UnityEngine;
using System.Collections;

public class BattleStateEnemyChoice{

	public void EnemyAction(BaseCharacterClass Enemy1,BaseCharacterClass Enemy2)
    {
        //ability
        if(Enemy1.Health>0)
        {
            ChooseMeleeEnemyAbility(Enemy1);
        }
        if (Enemy2.Health > 0)
        {
            ChooseMeleeEnemyAbility(Enemy2);
        }
        //damage
        //end
    }
    public void EnemyAction(BaseCharacterClass Enemy1, BaseCharacterClass Enemy2, BaseCharacterClass Enemy3)
    {
        //ability
        //damage
        //end
    }
    public BaseAbility ChooseMeleeEnemyAbility(BaseCharacterClass enemy)
    {
        return enemy.ability1;
    }
    public BaseAbility ChooseHealerEnemyAbility(BaseCharacterClass enemy)
    {
        return enemy.ability2;
    }
}
