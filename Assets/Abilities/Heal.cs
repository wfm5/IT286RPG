[System.Serializable]
public class Heal : BaseAbility {

	public Heal()
    {
        AbilityName = "Heal";
        isMagic = true;
        multiplier = .5f;
        TargetCount = 1;
        AbilityCost = 25;
    }
}
