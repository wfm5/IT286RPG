using UnityEngine;
using System.Collections;

public class BattleCalculations
{
    private int totalWarriorDamage;
    private int totalMageDamage;
    private int totalHealerDamage;

    private int totalWarriorCost;
    private int totalMageCost;
    private int totalHealerCost;

    public void CalculatePlayerForTurn(BaseAbility used1, BaseAbility used2, BaseAbility used3)
    {
        //1 should always be warrior, 2 should always be mage, 3 should always be healer
        totalWarriorDamage = PlayerParty.Warrior.Attack/used1.multiplier;
        totalWarriorCost = used1.abilityCost;

        if (used2.isMagic)
        {
            totalMageDamage = PlayerParty.Mage.Magicattack / used2.multiplier;
            totalMageCost = used2.abilityCost;
        }else if (!used2.isMagic)
        {
            totalMageDamage = PlayerParty.Mage.Attack / used2.multiplier;
            totalMageCost = used2.abilityCost;
        }

        if (used3.isMagic)
        {
            totalHealerDamage = PlayerParty.Healer.Magicattack / used3.multiplier;
            totalHealerCost = used3.abilityCost;
        }else if (!used3.isMagic)
        {
            totalHealerDamage = PlayerParty.Healer.Attack / used3.multiplier;
            totalHealerCost = used3.abilityCost;
        }
        //Enable player choices after calc for next turn
        BattleGUI.WarChoose = false;
        BattleGUI.MageChoose = false;
        BattleGUI.HealChoose = false;

        BattleGUI.WarSet = false;
        BattleGUI.MageSet = false;
        BattleGUI.HealSet = false;
        //Apply damage here or somewhere else
        //Continue to enemy turn
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
    }
}