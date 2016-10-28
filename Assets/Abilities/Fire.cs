using UnityEngine;
using System.Collections;

public class Fire : BaseAbility {

    public Fire()
    {
        AbilityName = "Fire";
        isMagic = true;
        IsHostile = true;
        IsAoe = false;
        multiplier = .75f;
        TargetCount = 1;
        AbilityCost = 30;
    }
	
}
