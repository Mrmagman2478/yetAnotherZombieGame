using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Camera_Movement : MonoBehaviour
{

	Vector2 mouseLook;
    Vector2 smoothVector;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public GameObject player;
	
	void Update () {

        //var is auto in c++. Only works if type given straight after like here could replace with Vector2
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, md.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, md.y, 1f / smoothing);
        mouseLook += smoothVector;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
