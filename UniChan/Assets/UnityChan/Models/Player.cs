using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    //private float gravity = -9.8f;
    private float jumpPower;
    private int wa;
    private static int count = 0;
    private bool bjump;
    private float pos;
    CharacterController con;
    Animator animator;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        con = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>(); 
        wa = 0;
        pos = 0;
        bjump = false;
        jumpPower = 2800.0f * Time.deltaTime;

    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // h : x, v : z
        if(dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,                                                      // 2벡터
                dir,                                                                    // 1벡터
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir)  // 0 : 1벡터, 1 : 2벡터
           );
            transform.LookAt(transform.position + forward);
        }


        if(transform.position.y >= 0.07f && transform.position.y <= 0.081f)
        {
            bjump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!bjump)
            {
               // rb.AddForce(new Vector3(0, jumpPower, 0));
                transform.position += new Vector3(0, jumpPower*Time.deltaTime, 0);
                bjump = true;
            }
        }

        

        //transform.position = new Vector3(transform.position.x, pos, transform.position.z);

        con.Move(dir * moveSpeed * Time.deltaTime);

        animator.SetFloat("Speed", con.velocity.magnitude);
        animator.SetFloat("JumpWait", transform.position.y);
        
	}
    
}
