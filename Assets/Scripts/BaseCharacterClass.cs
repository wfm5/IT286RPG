using UnityEngine;
using System.Collections;

public class BaseCharacterClass  {

    private string characterClassName;
    // Stats
    private float currenthealth;
    private int maxHealth;
    private float attack;
    private float magicattack;
    private float defense;
    private float magicdefense;
    private float currenttech;
    private float tech;
    private float currentmana;
    private float mana;
    private int buffed; //countdown -> if buffed > 0 apply stat boosts
    private int buffedH; // healerbuff
    private bool isDoping;
    private bool isDivLit;
    public BaseAbility ability1;
    public BaseAbility ability2;
    public BaseAbility ability3;
    public BaseAbility ability4;
    public BaseAbility ability5;

    public string CharacterClassName{
        get { return characterClassName;}
        set { characterClassName = value;}
    }
    public float Health{
        get { return currenthealth;}
        set { currenthealth = value;}
    }
    public int MaxHealth{
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public float Attack{
        get { return attack;}
        set { attack = value;}
    }
    public float Magicattack
    {
        get { return magicattack;}
        set { magicattack = value;}
    }
    public float Defense
    {
        get { return defense;}
        set { defense = value;}
    }
    public float Magicdefense
    {
        get { return magicdefense;}
        set { magicdefense = value;}
    }
    public float CurrentTech
    {
        get { return currenttech; }
        set { currenttech = value; }
    }
    public float MaxTech
    {
        get { return tech;}
        set { tech = value;}
    }
    public float CurrentMana
    {
        get { return currentmana; }
        set { currentmana = value; }
    }
    public float MaxMana
    {
        get { return mana;}
        set { mana = value;}
    }
    public int Buffed
    {
        get { return buffed; }
        set { buffed = value; }
    }
    public int BuffedH
    {
        get { return buffedH; }
        set { buffedH = value; }
    }
    public bool IsDoping
    {
        get { return isDoping; }
        set { value = isDoping; }
    }
    public bool IsDivLit
    {
        get { return isDivLit; }
        set { value = isDivLit; }
    }
}

