[System.Serializable]
public class Doping : BaseAbility {

	public Doping()
    {
        AbilityName = "Doping";
        multiplier = .25f;
        TargetCount = 1;
        AbilityCost = 35;
    }
}
