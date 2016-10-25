[System.Serializable]
public class Heal : BaseAbility {

	public Heal()
    {
        AbilityName = "Heal";
        TargetCount = 1;
        AbilityCost = 25;
    }
}
