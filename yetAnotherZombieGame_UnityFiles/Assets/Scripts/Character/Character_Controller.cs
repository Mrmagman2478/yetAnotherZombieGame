using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    //public fields
    public float characterSpeed = 10;
    public float characterJumpHeight = 0.1f;
    //visiable fields that none editable
    [SerializeField]
    int kills = 0;
	void Start () {
        //allow custom speed and jumpheight while keeping movement variavble private
        gameObject.GetComponent<Character_Movement>().setMovementModifier(characterSpeed, characterJumpHeight);
    }
	void Update () {
		
	}
    public int getKills() { return kills; }

    public void addKill() { kills++; }
}
