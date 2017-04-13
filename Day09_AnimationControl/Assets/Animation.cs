using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    public Animator anim;
    public Rigidbody rb;

    private float inputH;
    private float inputV;
    private bool run;

	// Use this for initialization
	void Start () {
        // print("log");   // == Debug.Log()
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1"))
        {
            anim.Play("SLIDE00", 0, 0.5f);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        anim.SetBool("run", run);

        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if(run)
        {
            moveX *= 3f;
            moveZ *= 3f;
        }

        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
