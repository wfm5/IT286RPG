using UnityEngine;
using System.Collections;

public class Fire : BaseAbility {

    public Fire()
    {
        abilityName = "Fire";
        isMagic = true;
        multiplier = .75f;
        TargetCount = 1;
        AbilityCost = 30;
    }
	
}
