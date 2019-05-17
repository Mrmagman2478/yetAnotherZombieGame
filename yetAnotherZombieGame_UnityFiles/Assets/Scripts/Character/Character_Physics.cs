using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Physics : MonoBehaviour {

    [SerializeField]
    private Planet_Physics planet;

    private Rigidbody body;


	void Start () {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation;
        body.useGravity = false;
    }
	
	void Update () {
        planet.Gravity(gameObject);
	}
}
