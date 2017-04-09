using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 360f;
    public float jumpSpeed;
    private float gravity = 20.0f;
    private float jumpPower;
    CharacterController con;
    private int jumpHash1 = Animator.StringToHash("Jump1");
    private int jumpHash2 = Animator.StringToHash("Jump2");
    private int runStateHash = Animator.StringToHash("Base Layer.Run");
    private int waitStateHash = Animator.StringToHash("Base Layer.Wait");
    private bool bGround;
    Animator animator;
    Rigidbody rb;
    private bool bjump;
    Vector3 dir;
    // Use this for initialization
    void Start () {
        con = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody>(); 
        
        bjump = false;
        bGround = false;
        jumpPower = 2800.0f * Time.deltaTime;
        dir = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        

        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // h : x, v : z

        if (dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,                                                      // 2벡터
                dir,                                                                    // 1벡터
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir)  // 0 : 1벡터, 1 : 2벡터
            );
            transform.LookAt(transform.position + forward);
        }

        dir *= moveSpeed;

        if (con.isGrounded)
        {
            // dir *= moveSpeed;

            bjump = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo(0); // base index

                if (animState.fullPathHash == runStateHash)
                {
                    animator.SetTrigger(jumpHash2);
                }
                else if (animState.fullPathHash == waitStateHash)
                {
                    animator.SetTrigger(jumpHash1);
                    
                }
                bjump = true;
                //rb.AddForce(new Vector3(0, jumpSpeed*10, 0));
                
            }
           

        }

        if(bjump)
        {
            con.Move(Vector3.up * jumpSpeed * Time.deltaTime);
        }
        
        con.SimpleMove(dir);
        animator.SetFloat("Speed", con.velocity.magnitude);

        //        dir.y -= gravity;
        /*
                if (dir.y <= 0.0f)
                {
                    dir.y = 0.0f;
                }
                */






        //transform.position = new Vector3(transform.position.x, pos, transform.position.z);

        //con.Move(dir * moveSpeed * Time.deltaTime);


        //animator.SetFloat("JumpWait", transform.position.y);

    }



    
}
