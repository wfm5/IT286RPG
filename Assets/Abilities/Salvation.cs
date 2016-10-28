using UnityEngine;
using System.Collections;

public class Salvation : BaseAbility {

	public Salvation()
    {
        AbilityName = "Salvation";
        IsMagic = true;
        IsHostile = false;
        IsAoe = true;
        multiplier = .5f;
        TargetCount = 3;
        AbilityCost = 55;
    }
}
