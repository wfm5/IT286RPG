using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

    public GameObject PartyInfoText;
    public GameObject EnemyInfoText;
    public GameObject BattleLogText;
    public GameObject EndGameText;

    public Text partyText;
    public Text enemyText;
    public static Text battleText;

    public GUIStyle tooltipStyle;

    public string warriorText;
    public string mageText;
    public string healerText;

    public string enemyText1;
    public string enemyText2;
    public string enemyText3;

    public string winText;
    public string loseText;

    public static bool WarChoose = false;
    public static bool MageChoose = false;
    public static bool HealChoose = false;

    public static bool WarSet = false;
    public static bool MageSet = false;
    public static bool HealSet = false;

    public static bool WarTarg = false;
    public static bool MageTarg = false;
    public static bool HealTarg = false;

    // Use this for initialization
    void Start ()
    {
        PartyInfoText = GameObject.Find("PartyInfo");
        partyText = PartyInfoText.GetComponent<Text>();

        EnemyInfoText = GameObject.Find("EnemyInfo");
        enemyText = EnemyInfoText.GetComponent<Text>();

        BattleLogText = GameObject.Find("BattleLog");
        battleText = BattleLogText.GetComponent<Text>();

        tooltipStyle = new GUIStyle();
        tooltipStyle.fontSize = 14;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Update the party info every frame
        warriorText = PlayerParty.Warrior.CharacterClassName + "\n HP: " + PlayerParty.Warrior.Health + "/" + PlayerParty.Warrior.MaxHealth + "\n TP: " + PlayerParty.Warrior.CurrentTech + "/" + PlayerParty.Warrior.MaxTech + "\n\n\n\n\n\n\n\n";
        mageText = PlayerParty.Mage.CharacterClassName + "\n HP: " + PlayerParty.Mage.Health + "/" + PlayerParty.Mage.MaxHealth + "\n MP: " + PlayerParty.Mage.CurrentMana + "/" + PlayerParty.Mage.MaxMana + "\n\n\n\n\n\n\n\n";
        healerText = PlayerParty.Healer.CharacterClassName + "\n HP: " + PlayerParty.Healer.Health + "/" + PlayerParty.Healer.MaxHealth + "\n MP: " + PlayerParty.Healer.CurrentMana + "/" + PlayerParty.Healer.MaxMana + "\n";

        partyText.text = "" + warriorText + mageText + healerText + "\n Press Esc to close.";
        //Update Enemy info every frame
        enemyText1 = BattleStateStart.Enemy1.CharacterClassName + "\n HP: " + BattleStateStart.Enemy1.Health + "/" + BattleStateStart.Enemy1.MaxHealth + "\n";
        enemyText2 = BattleStateStart.Enemy2.CharacterClassName + "\n HP: " + BattleStateStart.Enemy2.Health + "/" + BattleStateStart.Enemy2.MaxHealth + "\n";
        if(BattleStateStart.Enemy3.Attack != 0)
           enemyText3 = BattleStateStart.Enemy3.CharacterClassName + "\n HP: " + BattleStateStart.Enemy3.Health + "/" + BattleStateStart.Enemy3.MaxHealth + "\n";

        enemyText.text = "" + enemyText1 + enemyText2 + enemyText3;

        
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
        if (PlayerParty.Warrior.Health > 0f)
        {
            if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 100, 75, 30), "Warrior"))
            {                
                WarChoose = true;
            }
        }
        else { WarChoose = true; WarSet = true; WarTarg = true; }

        if (PlayerParty.Mage.Health > 0f) {
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) - 75, Screen.height - 100, 75, 30), "Mage"))
            {
                MageChoose = true;
            }
        }
        else { MageChoose = true; MageSet = true; MageTarg = true; }
        if (PlayerParty.Healer.Health > 0f)
        {
            if (GUI.Button(new Rect(100, Screen.height - 100, 75, 30), "Healer"))
            {
                HealChoose = true;
            }
        }
        else { HealChoose = true; HealSet = true; HealTarg = true; }

        //Menu 2
        if (WarChoose && !WarSet)
        {
            if(GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Warrior.ability1.abilityName,"Deals Physical Damage to one target.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[0] = PlayerParty.Warrior.ability1;
                WarSet = true;
            }
            if(GUI.Button(new Rect(Screen.width - 190, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Warrior.ability2.abilityName,"Deals Damage to all enemies.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[0] = PlayerParty.Warrior.ability2;
                WarSet = true;
            }
            if(GUI.Button(new Rect(Screen.width - 130, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Warrior.ability3.abilityName, "Boosts own HP.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[0] = PlayerParty.Warrior.ability3;
                WarSet = true;
            }
        }
        if (MageChoose && !MageSet)
        {
            if (GUI.Button(new Rect((Screen.width - Screen.width/2)-105, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Mage.ability1.abilityName, "Deals Physical Damage to one target.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability1;
                MageSet = true;

            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2)-45, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Mage.ability2.abilityName, "Deals Fire damage. 75% Potent. 30 Mana.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability2;
                MageSet = true;

            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) + 10, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Mage.ability3.abilityName, "Deals Ice Damage. 50% Potent. 15 Mana.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability3;
                MageSet = true;

            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) + 65, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Mage.ability4.abilityName, "Deals Null Elemental damage. 25% Potent. 5 Mana")))
            {
                TurnBasedCombatStateMachine.usedAbilities[1] = PlayerParty.Mage.ability4;
                MageSet = true;
            }
        }
        if (HealChoose && !HealSet)
        {
            if (GUI.Button(new Rect(5, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Healer.ability1.abilityName, "Deals Physical damage to one enemy.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability1;
                HealSet = true;
            }
            if (GUI.Button(new Rect(60, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Healer.ability2.abilityName, "Heals one target ally. 50% potent. 25 Mana.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability2;
                HealSet = true;
            }
            if(GUI.Button(new Rect(115, Screen.height - 50, 50, 30), new GUIContent(PlayerParty.Healer.ability3.abilityName, "Attacks one target with Null elemental damage. Restores Mana.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability3;
                HealSet = true;
            }
            if (GUI.Button(new Rect(170, Screen.height - 50, 80, 30), new GUIContent(PlayerParty.Healer.ability4.abilityName, "Raises Party's Defenses and Max Health. 100 Mana.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability4;
                HealSet = true;
            }
            if (GUI.Button(new Rect(255, Screen.height - 50, 70, 30), new GUIContent(PlayerParty.Healer.ability5.abilityName, "Restores the entire Party's Health. 50% Potent. 55 Mana.")))
            {
                TurnBasedCombatStateMachine.usedAbilities[2] = PlayerParty.Healer.ability5;
                HealSet = true;
            }
        }
        //Menu 3
        if(WarChoose && WarSet && !WarTarg )
        {
            if (TurnBasedCombatStateMachine.usedAbilities[0].isHostile)
            {
                if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 55, 30), BattleStateStart.Enemy1.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[0] = BattleStateStart.Enemy1;
                    WarTarg = true;
                }
                if (GUI.Button(new Rect(Screen.width - 190, Screen.height - 50, 60, 30), BattleStateStart.Enemy2.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[0] = BattleStateStart.Enemy2;
                    WarTarg = true;
                }
                if (BattleStateStart.Enemy3.Attack > 0)
                {
                    if (GUI.Button(new Rect(Screen.width - 130, Screen.height - 50, 60, 30), BattleStateStart.Enemy3.CharacterClassName))
                    {
                        TurnBasedCombatStateMachine.targetEnemies[0] = BattleStateStart.Enemy3;
                        WarTarg = true;
                    }
                }
            }else if (!TurnBasedCombatStateMachine.usedAbilities[0].isHostile)
            {
                if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 55, 30), PlayerParty.Warrior.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[0] = PlayerParty.Warrior;
                    WarTarg = true;
                }
            }
        }
        if (MageChoose && MageSet && !MageTarg)
        {
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) - 105, Screen.height - 50, 55, 30), BattleStateStart.Enemy1.CharacterClassName))
            {
                TurnBasedCombatStateMachine.targetEnemies[1] = BattleStateStart.Enemy1;
                MageTarg = true;
            }
            if (GUI.Button(new Rect((Screen.width - Screen.width / 2) - 45, Screen.height - 50, 60, 30), BattleStateStart.Enemy2.CharacterClassName))
            {
                TurnBasedCombatStateMachine.targetEnemies[1] = BattleStateStart.Enemy2;
                MageTarg = true;
            }
            if (BattleStateStart.Enemy3.Attack > 0)
            {
                if (GUI.Button(new Rect((Screen.width - Screen.width / 2) + 10, Screen.height - 50, 60, 30), BattleStateStart.Enemy3.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[1] = BattleStateStart.Enemy3;
                    MageTarg = true;
                }
            }
        }
        if (HealChoose && HealSet && !HealTarg)
        {
            if (TurnBasedCombatStateMachine.usedAbilities[2].IsHostile == true)
            {
                if (GUI.Button(new Rect(5, Screen.height - 50, 55, 30), BattleStateStart.Enemy1.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[2] = BattleStateStart.Enemy1;
                    HealTarg = true;
                }
                if (GUI.Button(new Rect(65, Screen.height - 50, 60, 30), BattleStateStart.Enemy2.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[2] = BattleStateStart.Enemy2;
                    HealTarg = true;
                }
                if (BattleStateStart.Enemy3.Attack > 0)
                {
                    if (GUI.Button(new Rect(130, Screen.height - 50, 60, 30), BattleStateStart.Enemy3.CharacterClassName))
                    {
                        TurnBasedCombatStateMachine.targetEnemies[2] = BattleStateStart.Enemy3;
                        HealTarg = true;
                    }
                }
            }
            else if (TurnBasedCombatStateMachine.usedAbilities[2].IsHostile == false)
            {
                if (GUI.Button(new Rect(5, Screen.height - 50, 55, 30), PlayerParty.Warrior.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[2] = PlayerParty.Warrior;
                    HealTarg = true;
                }
                if (GUI.Button(new Rect(65, Screen.height - 50, 60, 30), PlayerParty.Mage.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[2] = PlayerParty.Mage;
                    HealTarg = true;
                }                
                if (GUI.Button(new Rect(130, Screen.height - 50, 60, 30), PlayerParty.Healer.CharacterClassName))
                {
                    TurnBasedCombatStateMachine.targetEnemies[2] = PlayerParty.Healer;
                    HealTarg = true;
                }
                
            }
        }
        //Output to BattleLog
        if (WarTarg && HealTarg && MageTarg)
        {
            battleText.text = "";
            battleText.text += "Turn: " + TurnBasedCombatStateMachine.turnCount + "\n";
            battleText.text += PlayerParty.Warrior.CharacterClassName + " used " + TurnBasedCombatStateMachine.usedAbilities[0].AbilityName + "\n";
            battleText.text += PlayerParty.Mage.CharacterClassName + " used " + TurnBasedCombatStateMachine.usedAbilities[1].AbilityName + "\n";
            battleText.text += PlayerParty.Healer.CharacterClassName + " used " + TurnBasedCombatStateMachine.usedAbilities[2].AbilityName + "\n";
        }
        GUI.color = Color.black;        
        GUI.Label(new Rect(Input.mousePosition.x,-Input.mousePosition.y+Screen.height-50, 100,100), GUI.tooltip, tooltipStyle);
        //Debug.Log("x: " + Input.mousePosition.x + "y: " + Input.mousePosition.y );
        
        //Change phase
        if (WarTarg && MageTarg && HealTarg)
        {
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        }
    } 
    
}
