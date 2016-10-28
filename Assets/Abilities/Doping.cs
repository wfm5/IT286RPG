using UnityEngine;
using System;
[System.Serializable]

public class Doping : BaseAbility {

	public Doping()
    {
        AbilityName = "Doping";
        IsHostile = false;
        IsAoe = false;
        IsMagic = false;
        multiplier = 1.25f;
        TargetCount = 1;
        AbilityCost = 35;
    }
    public static void ApplyDoping(BaseCharacterClass target)
    {
        if (target.Buffed == 0)
        {
            target.IsDoping = true;
            target.Buffed = 3;
            target.Defense = (float)Math.Ceiling(target.Defense *= target.ability3.multiplier);
            target.Magicdefense = (float)Math.Ceiling(target.Magicdefense *= target.ability3.multiplier);
            target.MaxHealth += 10;
        }
        else if (target.Buffed > 0)
            target.Buffed = 3;
    }
    public static void RemoveDoping(BaseCharacterClass target)
    {        
        if (target.Buffed == 0 && (target.IsDoping == true))
        {
            target.IsDoping = false;
            target.Defense = (float)Math.Ceiling(target.Defense /= target.ability3.multiplier);
            target.Magicdefense = (float)Math.Ceiling(target.Magicdefense /= target.ability3.multiplier);
            target.MaxHealth -= 10;
        }
    }
}
