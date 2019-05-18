using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float damage = 5;
    [SerializeField]
    GameObject myslef;
    bool runOnce = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            if (other.gameObject.GetComponent<Health>().checkLifeSigns() == true)
            {
                if (other.gameObject.GetComponent<Health>().takeDamage(damage) == true)
                {
                    Debug.Log("Kill");
                    if (runOnce)
                    {
                        myslef.GetComponent<Character_Controller>().addKill();
                        myslef.GetComponent<Character_Controller>().addScore(10);
                        runOnce = false;
                    }
                }
            }

            Destroy(this.gameObject);
        }
    }
    public void setMyslefAsOwn(GameObject me) { myslef = me;}
}
