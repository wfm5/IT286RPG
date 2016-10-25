using UnityEngine;
using System.Collections;

public class BaseHealerClass : BaseCharacterClass {

    public BaseHealerClass()
    {
        CharacterClassName = "Healer";
        Health = 20;
        Attack = 5;
        Magicattack = 20;
        Defense = 5;
        Magicdefense = 8;
        Tech = 0;
        Mana = 250;
        ability1 = new NormalAttack();
        ability2 = new Heal();
        //ability3 = new Sap();
        //ability4 = new DivineLight();
        //ability5 = Salvation();
    }
}
