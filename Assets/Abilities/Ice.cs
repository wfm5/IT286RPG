using UnityEngine;
using System.Collections;

public class Ice : BaseAbility {

	public Ice()
    {
        AbilityName = "Ice";
        IsMagic = true;
        IsHostile = true;
        IsAoe = false;
        multiplier = .5f;
        TargetCount = 1;
        AbilityCost = 15;
    }
}
