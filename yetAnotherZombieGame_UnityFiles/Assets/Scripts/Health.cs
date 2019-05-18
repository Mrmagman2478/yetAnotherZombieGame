using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour {

    public float health = 100;
    float respawnHealth;
    private bool isAlive = true;
    private bool respawn = false;
    public GameObject myslef;
    Animator Anime;

    float time;
    float deathtime = 1.6f;
    void Start () {
        Anime = this.gameObject.GetComponent<Animator>();
        myslef = this.gameObject;
        respawnHealth = health;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //handle player respawn and any other objects that be reused.
		if(respawn)
        {
            health = respawnHealth;
            respawn = false;
            if (this.gameObject.GetComponent<NavMeshAgent>() != null)
            {
                this.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            }
            time = 0;
            
        }
        //if health falls to 0 or less kill the gameObject related to this.
        if (health <= 0)
        {
            time += Time.deltaTime;
            Anime.SetBool("Die", true);
            isAlive = false;
            if (this.gameObject.GetComponent<NavMeshAgent>() != null)
            {
                this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            if (time > deathtime)
            {
                if (myslef.layer == LayerMask.NameToLayer("Player"))
                {
                    myslef.GetComponent<Character_Movement>().enabled = false;
                    myslef.GetComponentInChildren<Character_Camera_Movement>().enabled = false;
                    myslef.GetComponent<Gun_Script>().enabled = false;
                }
                else
                {
                    Destroy(myslef);
                }
            }
        }


	}
    //Allow other code to check if they're alive
    public bool checkLifeSigns()
    {
        return isAlive;
    }
    public float getHealth() { return health; }
    //alow other code to tell gameobject to respawn
    public void setRespawn()
    {
        respawn = true;
    }
    public bool takeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void giveHealth(float heal)
    {
        health = health + heal;
    }
}
