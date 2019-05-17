using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Physics : MonoBehaviour {
    //Default gravity based of character home planet(Based of Earth gravity)
    private const float gravity = -9.8f;
    //This planet gravity
    public float planetsGravity;
    //Using default gravity figure out what G this planet has character planet will be 1G
    public float GravitionalForce;

    void Start()
    {
        //if set to + value in inspector still works as gravity
        if(planetsGravity > 0)
        {
            planetsGravity = -planetsGravity;
        }
        GravitionalForce = -planetsGravity / -gravity;
    }
    public void Gravity (GameObject obj)
    {
        Vector3 gravityUp = (obj.transform.position - transform.position).normalized;
        Vector3 localUo = obj.transform.up;

        obj.GetComponent<Rigidbody>().AddForce(gravityUp * planetsGravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUo, gravityUp) * obj.transform.rotation;
        obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
