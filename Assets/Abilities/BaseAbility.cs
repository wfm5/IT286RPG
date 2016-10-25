[System.Serializable]
public class BaseAbility {

    public string abilityName;
    public int targetCount;
    public int abilityCost;

    public string AbilityName
    {
        get { return abilityName;}
        set {abilityName = value;}
    }
    public int TargetCount
    {
        get { return targetCount; }
        set { targetCount = value; }
    }
    public int AbilityCost
    {
        get { return abilityCost;}
        set { abilityCost = value;}
    }
}