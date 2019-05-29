using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    float damage = 5;
    public GameObject DamageTxt;
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
                    DamagaePopUp(other);
                    Debug.Log("Kill");
                    if (runOnce)
                    {

                        myslef.GetComponent<Character_Controller>().addKill();
                        myslef.GetComponent<Character_Controller>().addScore(10);
                        runOnce = false;
                    }
                }
                else
                {
                    DamagaePopUp(other);
                }
            }

            Destroy(this.gameObject);
        }
    }
    public void setMyslefAsOwn(GameObject me) { myslef = me;}

    public void DamagaePopUp(Collider other)
    {
        GameObject Txt = Instantiate(DamageTxt, other.gameObject.transform.position, other.gameObject.transform.rotation);
        Txt.GetComponentInChildren<Text>().text = damage.ToString();
        Destroy(Txt, Txt.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0).Length);
    }
    public void setDamage(int d) { damage = d;}
}


