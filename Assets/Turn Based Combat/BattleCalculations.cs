using UnityEngine;
using System.Collections;

public class BattleCalculations
{
    private float totalWarriorDamage;
    private float totalMageDamage;
    private float totalHealerDamage;

    private float totalWarriorCost;
    private float totalMageCost;
    private float totalHealerCost;

    private float reducedWarriorDamage;
    private float reducedMageDamage;
    private float reducedHealerDamage;

    public void CalculatePlayerForTurn(BaseAbility used1, BaseAbility used2, BaseAbility used3)
    {
        reducedWarriorDamage = 0f;
        reducedMageDamage = 0f;
        reducedHealerDamage = 0f;

        //gathers up damage for turn
        //1 should always be warrior, 2 should always be mage, 3 should always be healer
        if (used1.IsHostile)
        {
            totalWarriorDamage = PlayerParty.Warrior.Attack * used1.multiplier;
            totalWarriorCost = used1.abilityCost;
            reducedWarriorDamage = totalWarriorDamage - TurnBasedCombatStateMachine.targetEnemies[0].Defense;
            if (reducedWarriorDamage < 0)
                reducedWarriorDamage = 1;
            if (used1.AbilityName == "Swipe")
            {
                SwipeAll(BattleStateStart.Enemy1, BattleStateStart.Enemy2, BattleStateStart.Enemy3);
                reducedWarriorDamage = 0;
            }
        }else if (!used1.IsHostile)
        {
            Doping.ApplyDoping(PlayerParty.Warrior);
        }

        if (used2.isMagic)
        {
            totalMageDamage = PlayerParty.Mage.Magicattack * used2.multiplier;
            totalMageCost = used2.abilityCost;
            reducedMageDamage = totalMageDamage - TurnBasedCombatStateMachine.targetEnemies[1].Magicdefense;
            if (reducedMageDamage < 0)
                reducedMageDamage = 1;
        }
        else if (!used2.isMagic)
        {
            totalMageDamage = PlayerParty.Mage.Attack * used2.multiplier;
            totalMageCost = used2.abilityCost;
            reducedMageDamage = totalMageDamage - TurnBasedCombatStateMachine.targetEnemies[1].Defense;
            if (reducedMageDamage < 0)
                reducedMageDamage = 1;
        }

        if (used3.isMagic && used3.IsHostile)
        {
            //only sap
            totalHealerDamage = PlayerParty.Healer.Magicattack * used3.multiplier;
            totalHealerCost = used3.abilityCost;
            reducedHealerDamage = totalHealerDamage - TurnBasedCombatStateMachine.targetEnemies[2].Magicdefense;
            if (reducedHealerDamage < 0)
                reducedHealerDamage = 1;
            PlayerParty.Healer.CurrentMana += reducedHealerDamage;
        }
        else if (!used3.isMagic && used3.IsHostile)
        {
            totalHealerDamage = PlayerParty.Healer.Attack * used3.multiplier;
            totalHealerCost = used3.abilityCost;
            reducedHealerDamage = totalHealerDamage - TurnBasedCombatStateMachine.targetEnemies[2].Defense;
            if (reducedHealerDamage < 0)
                reducedHealerDamage = 1;
        } else if(used3.IsMagic && !used3.IsHostile)
        {
            if (used3.AbilityName == "Heal")
            {
                totalHealerDamage = PlayerParty.Healer.Magicattack * (-1 * used3.multiplier);
                totalHealerCost = used3.AbilityCost;
                reducedHealerDamage = totalHealerDamage;
            }else if (used3.AbilityName == "Divine Light")
            {
               DivineLight.ApplyDivineLight(PlayerParty.Warrior,PlayerParty.Mage,PlayerParty.Healer);
            }else if(used3.abilityName == "Salvation")
            {
                totalHealerDamage = PlayerParty.Healer.Magicattack * (-1 * used3.multiplier);
                totalHealerCost = used3.AbilityCost;
                reducedHealerDamage = 0;// totalHealerDamage;
                HealParty(PlayerParty.Warrior,PlayerParty.Mage,PlayerParty.Healer);
            }
        }
        //Enable player choices after calc for next turn
        BattleGUI.WarChoose = false;
        BattleGUI.MageChoose = false;
        BattleGUI.HealChoose = false;

        BattleGUI.WarSet = false;
        BattleGUI.MageSet = false;
        BattleGUI.HealSet = false;

        BattleGUI.WarTarg = false;
        BattleGUI.MageTarg = false;
        BattleGUI.HealTarg = false;
        //Apply damage here 
        ApplyDamageToEnemy();
        //Pay your costs
        PayPlayerCosts();
        //Continue to enemy turn
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
    }
    public void ApplyDamageToEnemy()
    {
        if(PlayerParty.Warrior.Health > 0f)
          TurnBasedCombatStateMachine.targetEnemies[0].Health -= reducedWarriorDamage;
        if(PlayerParty.Mage.Health > 0f)
            TurnBasedCombatStateMachine.targetEnemies[1].Health -= reducedMageDamage;
        if(PlayerParty.Healer.Health > 0f)
            TurnBasedCombatStateMachine.targetEnemies[2].Health -= reducedHealerDamage;
    }
    public void HealParty(BaseCharacterClass target1, BaseCharacterClass target2, BaseCharacterClass target3)
    {
        target1.Health += PlayerParty.Healer.Magicattack * PlayerParty.Healer.ability5.multiplier;
        target2.Health += PlayerParty.Healer.Magicattack * PlayerParty.Healer.ability5.multiplier;
        target3.Health += PlayerParty.Healer.Magicattack * PlayerParty.Healer.ability5.multiplier;
    }
    public void SwipeAll(BaseCharacterClass target1, BaseCharacterClass target2, BaseCharacterClass target3)
    {
        target1.Health -= (PlayerParty.Warrior.Attack * PlayerParty.Warrior.ability2.multiplier) - target1.Defense;
        target2.Health -= (PlayerParty.Warrior.Attack * PlayerParty.Warrior.ability2.multiplier) - target2.Defense;
        if(target3.Attack > 0)
            target3.Health -= (PlayerParty.Warrior.Attack * PlayerParty.Warrior.ability2.multiplier) - target3.Defense;

    }
    public void PayPlayerCosts()
    {
        PlayerParty.Warrior.CurrentTech -= totalWarriorCost;
        PlayerParty.Mage.CurrentMana -= totalMageCost;
        PlayerParty.Healer.CurrentMana -= totalHealerCost;
    }
}