using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitDisplay : MonoBehaviour {
    Animator anim;
    Text text;
	// Use this for initialization
	void Start () {
        gameObject.GetComponentInChildren<Animator>();
        gameObject.GetComponentInChildren<Text>();
        Destroy(this.gameObject, anim.GetCurrentAnimatorClipInfo(0).Length);
	}
}
