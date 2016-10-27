[System.Serializable]
public class Heal : BaseAbility {

	public Heal()
    {
        AbilityName = "Heal";
        isMagic = true;
        multiplier = 2;
        TargetCount = 1;
        AbilityCost = 25;
    }
}
