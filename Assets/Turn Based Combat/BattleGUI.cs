using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

    public string meleeName1;
    public static bool WarChoose = false;
    public static bool MageChoose = false;
    public static bool HealChoose = false;

    public static bool WarSet = false;
    public static bool MageSet = false;
    public static bool HealSet = false;
   
    // Use this for initialization
    void Start ()
    {
        meleeName1 = PlayerParty.Warrior.CharacterClassName;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}
    void OnGUI()
    {
        if(TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            PlayerChoice();
        }
    }

    private void PlayerChoice()
    {
        //Menu 1
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 100, 75, 30), "Warrior"))
        {
            WarChoose = true;
        }
        if (GUI.Button(new Rect((Screen.width - Screen.width/2)-75, Screen.height - 100, 75, 30), "Mage"))
        {
            MageChoose = true;
        }
        if (GUI.Button(new Rect(Screen.width - 650, Screen.height - 100, 75, 30), "Healer"))
        {
            HealChoose = true;
        }
        //Menu 2
        if (WarChoose && !WarSet)
        {
            if(GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 50, 30), PlayerParty.Warrior.ability1.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[0] = PlayerParty.Warrior.ability1;
                WarSet = true;
            }
            if(GUI.Button(new Rect(Screen.width - 190, Screen.height - 50, 50, 30), PlayerParty.Warrior.ability2.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[0] = PlayerParty.Warrior.ability2;
                WarSet = true;
            }
            if(GUI.Button(new Rect(Screen.width - 130, Screen.height - 50, 50, 30), PlayerParty.Warrior.ability3.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[0] = PlayerParty.Warrior.ability3;
                WarSet = true;
            }
        }
        if (MageChoose && !MageSet)
        {
            if (GUI.Button(new Rect((Screen.width - Screen.width/2)-105, Screen.height - 50, 50, 30), PlayerParty.Mage.ability1.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability1;
                MageSet = true;

            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2)-45, Screen.height - 50, 50, 30), PlayerParty.Mage.ability2.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability2;
                MageSet = true;

            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) + 10, Screen.height - 50, 50, 30), PlayerParty.Mage.ability3.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability3;
                MageSet = true;

            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) + 65, Screen.height - 50, 50, 30), PlayerParty.Mage.ability3.abilityName))
            {
                //Dont forget to change this to 4
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability3;
                MageSet = true;

            }
        }
        if (HealChoose && !HealSet)
        {
            if (GUI.Button(new Rect(5, Screen.height - 50, 50, 30), PlayerParty.Healer.ability1.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability1;
                HealSet = true;
            }
            if (GUI.Button(new Rect(60, Screen.height - 50, 50, 30), PlayerParty.Healer.ability2.abilityName))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability2;
                HealSet = true;

            }
            // GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 50, 30), PlayerParty.Healer.ability3.abilityName);
        }
        if(HealSet && WarSet && MageSet)
        {
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        }
        

    } 
}
