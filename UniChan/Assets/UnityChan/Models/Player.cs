using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    //private float gravity = -9.8f;
    private float jumpPower;
    CharacterController con;
    private int jumpHash1 = Animator.StringToHash("Jump1");
    private int jumpHash2 = Animator.StringToHash("Jump2");
    private int runStateHash = Animator.StringToHash("Base Layer.Run");
    private int waitStateHash = Animator.StringToHash("Base Layer.Wait");
    Animator animator;
    Rigidbody rb;
    private bool bjump;

	// Use this for initialization
	void Start () {
        con = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>(); 
        
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

        /*
        if(transform.position.y >= 0.07f && transform.position.y <= 0.081f)
        {
            bjump = false;
        }
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
            if (!bjump)
            {
               // rb.AddForce(new Vector3(0, jumpPower, 0));
                transform.position += new Vector3(0, jumpPower*Time.deltaTime, 0);
                bjump = true;
            }*/

            AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo(0); // base index

            if(animState.fullPathHash == runStateHash)
            {
                animator.SetTrigger(jumpHash2);
            }
            else if(animState.fullPathHash == waitStateHash)
            {
                animator.SetTrigger(jumpHash1);
            }
            
        }

        

        //transform.position = new Vector3(transform.position.x, pos, transform.position.z);

        con.Move(dir * moveSpeed * Time.deltaTime);

        animator.SetFloat("Speed", con.velocity.magnitude);
        //animator.SetFloat("JumpWait", transform.position.y);
        
	}
    
}
