using UnityEngine;
using System.Collections;

public class BaseCharacterClass  {

    private string characterClassName;
    // Stats
    private int currenthealth;
    private int maxHealth;
    private int attack;
    private int magicattack;
    private int defense;
    private int magicdefense;
    private int tech;
    private int mana;
    private int buffed;
    public BaseAbility ability1;
    public BaseAbility ability2;
    public BaseAbility ability3;
    public BaseAbility ability4;
    public BaseAbility ability5;

    public string CharacterClassName{
        get { return characterClassName;}
        set { characterClassName = value;}
    }
    public int Health{
        get { return currenthealth;}
        set { currenthealth = value;}
    }
    public int MaxHealth{
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int Attack{
        get { return attack;}
        set { attack = value;}
    }
    public int Magicattack{
        get { return magicattack;}
        set { magicattack = value;}
    }
    public int Defense{
        get { return defense;}
        set { defense = value;}
    }
    public int Magicdefense{
        get { return magicdefense;}
        set { magicdefense = value;}
    }
    public int Tech{
        get { return tech;}
        set { tech = value;}
    }
    public int Mana{
        get { return mana;}
        set { mana = value;}
    }
    public int Buffed
    {
        get { return buffed; }
        set { buffed = value; }
    }
}

