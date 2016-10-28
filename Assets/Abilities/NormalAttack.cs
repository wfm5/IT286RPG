[System.Serializable]
public class NormalAttack : BaseAbility { 

    public NormalAttack()
    {
        AbilityName = "Attack";
        IsAoe = false;
        isMagic = false;
        IsHostile = true;
        multiplier = 1;
        TargetCount = 1;
        AbilityCost = 0;
    }
}
