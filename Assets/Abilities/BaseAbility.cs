[System.Serializable]
public class BaseAbility {

    public string abilityName;
    public bool isMagic;
    public float multiplier;
    public int targetCount;
    public int abilityCost;

    public string AbilityName
    {
        get { return abilityName;}
        set {abilityName = value;}
    }
    public bool IsMagic
    {
        get { return isMagic; }
        set { isMagic = value; }
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