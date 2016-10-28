using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
    GameObject move;
    
	// Use this for initialization
	void Start () {
        move = GameObject.Find("Swiper1");

	}
	
	// Update is called once per frame
	void Update () {
	if(BattleStateStart.Enemy1.Health <= 0)
        {
            Debug.Log(BattleStateStart.Enemy1.CharacterClassName);
            //move.gameObject.active = false;
        }
	}
}
