using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;

    private Rigidbody rbody;
    private Animator anim;

	// Use this for initialization
	void Start () {
        onGround = true;
        jumpPressure = 0;
        minJump = 2.0f;
        maxJumpPressure = 10.0f;

        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        anim.SetBool("onGround", onGround);
    }
	
	// Update is called once per frame
	void Update () {
		if(onGround)
        {
            if(Input.GetButton("Jump"))
            {
                if(jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
                anim.SetFloat("jumpPressure", jumpPressure + minJump);
                anim.speed = 1f + (jumpPressure / 10f);
            }
            else
            {
                if(jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rbody.velocity = new Vector3(jumpPressure / 10f, jumpPressure, 0);
                    jumpPressure = 0f;
                    onGround = false;
                    anim.SetFloat("jumpPressure", 0f);
                    anim.SetBool("onGround", onGround);
                    anim.speed = 1f;
                }
            }
        }
        else
        {
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            anim.SetBool("onGround", onGround);
        }
    }
}
