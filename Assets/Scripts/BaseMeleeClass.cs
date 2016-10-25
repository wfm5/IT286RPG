using UnityEngine;
using System.Collections;

public class BaseMeleeClass : BaseCharacterClass {
    public BaseMeleeClass() {
        CharacterClassName = "Warrior";
        Health = 50;
        Attack = 20;
        Magicattack = 0;
        Defense = 5;
        Magicdefense = 8;
        Tech = 100;
        Mana = 0;
        ability1 = new NormalAttack();
        ability2 = new Swipe();
        ability3 = new Doping();
    }
}
