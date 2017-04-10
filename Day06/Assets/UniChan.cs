using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniChan : MonoBehaviour {

    private bool m_mouseLockFlag;
    
    public GameObject playerObject = null;
    public GameObject bulletObject = null;
    public Transform bulletStartPosition = null; // 총구 위치

    private static readonly float MOVE_Z_FRONT = 3.0f;
    private static readonly float MOVE_Z_BACK = -2.0f;

    private static readonly float MOVE_X_LEFT = -2.0f;
    private static readonly float MOVE_X_RIGHT = 2.0f;

    private static readonly float ROTATION_Y_KEY = 360.0f;
    private static readonly float ROTATION_Y_MOUSE = 360.0f;

    private float m_rotationY = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckMouseLock();
        CheckMove();
	}

    private void CheckMouseLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_mouseLockFlag = !m_mouseLockFlag;
        }

        if(m_mouseLockFlag)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void CheckMove()
    {
        // 회전량
        {
            float addRotationY = 0.0f;

            if (Input.GetKey(KeyCode.Q))
            {
                addRotationY = -ROTATION_Y_KEY;
            }
            else if(Input.GetKey(KeyCode.E))
            {
                addRotationY = ROTATION_Y_KEY;
            }
            if(m_mouseLockFlag)
            {
                addRotationY += (Input.GetAxis("Mouse X") * ROTATION_Y_MOUSE);
            }
            m_rotationY += (addRotationY * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, m_rotationY, 0);
        }
        bool shiftFlag = false;

        Vector3 addPosition = Vector3.zero;
        {                                                                           // 앞뒤
            Vector3 vecInput = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
            if (vecInput.z > 0)
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    shiftFlag = true;
                    addPosition.z = MOVE_Z_FRONT * 2.5f;
                }
                else
                {
                    addPosition.z = MOVE_Z_FRONT;
                }
                
            }
            else if (vecInput.z < 0)
            {
                addPosition.z = MOVE_Z_BACK;
            }
         //   transform.position += ((transform.rotation * addPosition) * Time.deltaTime);
        }
        {                                                                           // 좌우
            Vector3 vecInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            if(vecInput.x > 0)
            {
                addPosition.x = MOVE_X_RIGHT;
            }
            else if(vecInput.x < 0)
            {
                addPosition.x = MOVE_X_LEFT;
            }
            
        }
        transform.position += ((transform.rotation * addPosition) * Time.deltaTime);

        {
            Debug.Log(isGrounded());

            if(isGrounded())
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.AddForce(new Vector3(0f, 5f, 0), ForceMode.VelocityChange); // 무게 고려 x 속도량, impact : 무게 고려
                                                                                   //rb.AddForce(new Vector3(0f, 250f, 0));
                }
            }
            
        }

        bool shootFlag = false;
        {
            if(Input.GetButtonDown("Fire1"))
            {
                shootFlag = true;
                if(null != bulletStartPosition)
                {
                    Vector3 vecBulletPos = bulletStartPosition.position;
                    vecBulletPos += (transform.rotation * Vector3.forward);
                    vecBulletPos.y = 1.0f;

                    Instantiate(bulletObject, vecBulletPos, transform.rotation);
                }
            }
            else
            {
                shootFlag = false;
            }
        }

        {
            Animator animator = playerObject.GetComponent<Animator>();
            animator.SetFloat("SpeedZ", addPosition.z);
            animator.SetBool("Shoot", shootFlag);
            animator.SetFloat("SpeedX", addPosition.x);
            animator.SetBool("Shift", shiftFlag);
        }
    }

    bool isGrounded()
    {
        //GameObject foot = GameObject.FindGameObjectWithTag("LeftToe");
        GameObject foot = GameObject.Find("Character1_LeftToeBase");
        return Physics.Raycast(foot.transform.position,Vector3.down,0.2f);    // 레이저를 쏴서 0.2f 사이에 collision이 있다면.
    }
}
