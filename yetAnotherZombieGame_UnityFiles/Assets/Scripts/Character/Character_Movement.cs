using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {

    private Rigidbody body;
    [SerializeField]
    float Pace = 10.0f;
    [SerializeField]
    float JumpHeight = 0.1f;
    [SerializeField]
    Animator animator;
    void Start () {
        body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Running", true);
                Pace = 15;
            }
            else
            {
                animator.SetBool("Running", false);
                Pace = 10.0f;
            }
        }
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {

        float translation = Input.GetAxis("Vertical") * Pace;
        float straffe = Input.GetAxis("Horizontal") * Pace;
        float jump = Input.GetAxis("Jump") * JumpHeight;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        if (animator != null)
        {
            animator.SetFloat("Movement", translation * 10);
        }

        transform.Translate(straffe, jump, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;


    }
    public void setMovementModifier(float cspeed,float cjumpheight) { Pace = cspeed; JumpHeight = cjumpheight;}
}
