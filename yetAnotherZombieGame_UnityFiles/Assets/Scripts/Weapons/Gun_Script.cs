using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSlot;
    public int Damage = 5;
    public float fireRate;
    public float fireSpeed;
    public float fireForce;
    public float spread;

    bool firstfire = true;
    public float time;
    float currentFireSpeed;
    float lastTime;


    void Start () {
        currentFireSpeed = fireSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        time = Time.time;
        if (Input.GetButton("Fire1"))
        {
            onFire();
        }
        else
        {
            if (time > fireSpeed)
            {
                firstfire = true;
            }
        }
	}

    void onFire()
    {
        lastTime = time;
        if(time > currentFireSpeed || firstfire)
        {
            currentFireSpeed = lastTime + fireSpeed;
            firstfire = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSlot.position, bulletSlot.rotation);
            //get main gameobject by getting this script parent gameobject and then getting it parent what is main gameobject.This will allow multiple character in later version
            bullet.GetComponent<Bullet>().setMyslefAsOwn(this.gameObject);
            bullet.GetComponent<Bullet>().setDamage(Damage);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSlot.forward * fireForce);
        }


    }
}
