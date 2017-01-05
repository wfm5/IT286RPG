[System.Serializable]
public class Swipe : BaseAbility {
    
    public Swipe()
    {
        AbilityName = "Swipe";
        isMagic = false;
        IsHostile = true;
        IsAoe = true;
        multiplier = .5f;
        TargetCount = 3;
        AbilityCost = 50;
    }
}
