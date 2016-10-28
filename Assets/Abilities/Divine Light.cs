using UnityEngine;
using System.Collections;
using System;

public class DivineLight : BaseAbility
{
    public DivineLight()
    {
        AbilityName = "Divine Light";
        IsMagic = true;
        IsAoe = true;
        IsHostile = false;
        multiplier = 1.2f;
        TargetCount = 3;
        AbilityCost = 100;
    }
    public static void ApplyDivineLight(BaseCharacterClass target1, BaseCharacterClass target2, BaseCharacterClass target3)
    {
        if ((target1.BuffedH == 0) && (target2.BuffedH == 0) && (target3.BuffedH == 0))
        {
            target1.BuffedH = target2.BuffedH = target3.BuffedH = 3;
            target1.IsDivLit = target2.IsDivLit = target3.IsDivLit = true;

            target1.Defense = (float)Math.Ceiling(target1.Defense *= PlayerParty.Healer.ability4.multiplier);            
            target1.Magicdefense = (float)Math.Ceiling(target1.Magicdefense *= PlayerParty.Healer.ability4.multiplier);
            target1.MaxHealth += 5;

            target2.Defense = (float)Math.Ceiling(target2.Defense *= PlayerParty.Healer.ability4.multiplier);
            target2.Magicdefense = (float)Math.Ceiling(target2.Magicdefense *= PlayerParty.Healer.ability4.multiplier);
            target2.MaxHealth += 5;

            target3.Defense = (float)Math.Ceiling(target3.Defense *= PlayerParty.Healer.ability4.multiplier);
            target3.Magicdefense = (float)Math.Ceiling(target3.Magicdefense *= PlayerParty.Healer.ability4.multiplier);
            target3.MaxHealth += 5;

        }else if (target1.BuffedH > 0)
        {
            target1.BuffedH = target2.BuffedH = target3.BuffedH = 3;
        }
    }
    public static void RemoveDivineLight(BaseCharacterClass target1, BaseCharacterClass target2, BaseCharacterClass target3)
    {        

        if (target1.BuffedH == 0 && target1.IsDivLit)
        {
            target1.IsDivLit = false;
            target1.Defense = (float)Math.Ceiling(target1.Defense /= PlayerParty.Healer.ability4.multiplier);
            target1.Magicdefense = (float)Math.Ceiling(target1.Magicdefense /= PlayerParty.Healer.ability4.multiplier);
            target1.MaxHealth -= 5;

            target2.IsDivLit = false;
            target2.Defense = (float)Math.Ceiling(target2.Defense /= PlayerParty.Healer.ability4.multiplier);
            target2.Magicdefense = (float)Math.Ceiling(target2.Magicdefense /= PlayerParty.Healer.ability4.multiplier);
            target2.MaxHealth -= 5;

            target3.IsDivLit = false;
            target3.Defense = (float)Math.Ceiling(target3.Defense /= PlayerParty.Healer.ability4.multiplier);
            target3.Magicdefense = (float)Math.Ceiling(target3.Magicdefense /= PlayerParty.Healer.ability4.multiplier);
            target3.MaxHealth -= 5;
        }
    }
}
