using UnityEngine;
using System.Collections;

public class BaseMageClass : BaseCharacterClass {
    public BaseMageClass()
    {
        CharacterClassName = "Mage";
        Health = 25;
        MaxHealth = 25;
        Attack = 2;
        Magicattack = 40;
        Defense = 2;
        Magicdefense = 5;
        MaxTech = 0;
        CurrentMana = 150;
        MaxMana = 150;
        ability1 = new NormalAttack();
        ability2 = new Fire();
        ability3 = new Ice();
        ability4 = new NullAttack();
    }

}
