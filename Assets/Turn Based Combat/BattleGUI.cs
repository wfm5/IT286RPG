using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour {

    public string meleeName1;
    private int currentHp;
    private int maxHp;
    private int currentMp;
    private int maxMp;
    private int currentTch;
    private int maxTch;
	// Use this for initialization
	void Start ()
    {
        meleeName1 = PlayerParty.Warrior.CharacterClassName;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
