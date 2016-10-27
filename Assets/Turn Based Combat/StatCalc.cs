using UnityEngine;
using System.Collections;

public class StatCalc : MonoBehaviour {

    public enum StatType
    {
        HEALTH,
        ATTACK,
        MAGICATTACK,
        DEFENSE,
        MAGICDEFENSE,
        MANA,
        TECH,
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public int CalculateHp(int statValue)
    {
        return statValue;
    }
    public int CalculateCost(int statValue)
    {
        return statValue;
    }
}
