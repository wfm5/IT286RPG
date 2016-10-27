[System.Serializable]
public class Swipe : BaseAbility {
    
    public Swipe()
    {
        AbilityName = "Swipe";
        isMagic = false;
        multiplier = .5f;
        TargetCount = 3;
        AbilityCost = 30;
    }
}
