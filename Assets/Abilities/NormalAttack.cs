[System.Serializable]
public class NormalAttack : BaseAbility { 

    public NormalAttack()
    {
        AbilityName = "Attack";
        isMagic = false;
        multiplier = 1;
        TargetCount = 1;
        AbilityCost = 0;
    }
}
