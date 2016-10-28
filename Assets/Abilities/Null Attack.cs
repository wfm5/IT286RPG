using UnityEngine;
using System.Collections;

public class NullAttack : BaseAbility {

	public NullAttack(){
        AbilityName = "Null";
        isMagic = true;
        isHostile = true;
        IsAoe = false;
        TargetCount = 1;
        multiplier = .25f;
        AbilityCost = 5;
    }
}
