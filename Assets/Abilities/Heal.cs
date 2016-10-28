[System.Serializable]
public class Heal : BaseAbility {

	public Heal()
    {
        AbilityName = "Heal";
        IsMagic = true;
        IsAoe = false;
        IsHostile = false;
        multiplier = .5f;
        TargetCount = 1;
        AbilityCost = 25;
    }
}
