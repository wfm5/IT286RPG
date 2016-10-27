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
        Tech = 0;
        Mana = 150;
        ability1 = new NormalAttack();
        ability2 = new Swipe();
        ability3 = new Doping();
    }

}
