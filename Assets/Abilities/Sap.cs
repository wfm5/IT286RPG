using UnityEngine;
using System.Collections;

public class Sap : BaseAbility {

	public Sap()
    {
        AbilityName = "Sap";
        IsMagic = true;
        IsAoe = false;
        IsHostile = true;
        multiplier = .1f;
        TargetCount = 1;
        AbilityCost = 0;
    }
}
