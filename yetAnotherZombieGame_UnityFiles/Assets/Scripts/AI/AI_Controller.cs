using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour {

    GameObject player;
    Animator Z_Anime;
    float damageDeal = 20;
    float time;
    bool multpleAttack = false;
    float timetilldamage;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Z_Anime = this.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        time = Time.time;
        if (player.GetComponent<Character_Movement>().enabled == true)
        {
            Z_Anime.SetBool("CanMove", true);
            if (Vector3.Distance(player.gameObject.transform.position, transform.position) < 5)
            {
                Z_Anime.SetBool("Attack", true);
            }
            else
            {
                Z_Anime.SetBool("Attack", false);
            }
        }
        else
        {
            Z_Anime.SetBool("Attack", false);
            Z_Anime.SetBool("CanMove", false);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (Z_Anime.GetBool("Attack"))
        {
            multpleAttack = false;
            collision.gameObject.GetComponent<Health>().takeDamage(damageDeal);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Z_Anime.GetBool("Attack"))
        {
            if (!multpleAttack)
            {
                timetilldamage = time + Z_Anime.GetCurrentAnimatorClipInfo(0).Length;
                multpleAttack = true;
            }
            else
            {
                if (time >= timetilldamage)
                {
                    timetilldamage = time + Z_Anime.GetCurrentAnimatorClipInfo(0).Length;
                    collision.gameObject.GetComponent<Health>().takeDamage(damageDeal);
                }
            }
        }
    }
}
