using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniChan : MonoBehaviour {

    private bool m_mouseLockFlag;
    
    public GameObject playerObject = null;
    public GameObject bulletObject = null;
    public Transform bulletStartPosition = null; // 총구 위치

    GameObject shoulder;

    private static readonly float MOVE_Z_FRONT = 3.0f;
    private static readonly float MOVE_Z_BACK = -2.0f;

    private static readonly float MOVE_X_LEFT = -2.0f;
    private static readonly float MOVE_X_RIGHT = 2.0f;

    private static readonly float ROTATION_Y_KEY = 360.0f;
    private static readonly float ROTATION_Y_MOUSE = 360.0f;
    private static readonly float ROTATION_X_KEY = -360.0f;
    private static readonly float ROTATION_X_MOUSE = -360.0f;
    private float m_rotationY = 0.0f;
    private float m_rotationX = 0.0f;
    bool jumpFlag = false;
    private float jumpCount;
    Camera[] cameras;

    // Use this for initialization
    void Start () {
        shoulder = GameObject.Find("Character1_Spine");
        jumpCount = 0;
        cameras = Camera.allCameras;
    }

    // Update is called once per frame
    void Update () {
        CheckMouseLock();
        CheckMove();
	}

    private void LateUpdate()
    {
        //shoulder.transform.rotation = Quaternion.Euler(m_rotationX, 0, 0);
        shoulder.transform.localEulerAngles = new Vector3(0, 0, m_rotationX);
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
            cameras[1].enabled = true;
            cameras[0].enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cameras[1].enabled = false;
            cameras[0].enabled = true;
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
           // transform.rotation = Quaternion.Euler(0, m_rotationY, 0);
        }
        // 상체 회전량
        {
            float addRotationX = 0.0f;

            if (m_mouseLockFlag)
            {
                if(m_rotationX < 30 && m_rotationX > 0)
                {
                    addRotationX -= (Input.GetAxis("Mouse Y") * ROTATION_X_MOUSE);

                    m_rotationX += (addRotationX * Time.deltaTime);
                 
                }
                else if(m_rotationX>-50 && m_rotationX < 0)
                {
                    addRotationX -= (Input.GetAxis("Mouse Y") * ROTATION_X_MOUSE);

                    m_rotationX += (addRotationX * Time.deltaTime);
                 
                }
                else if(m_rotationX == 0)
                {
                    addRotationX += (Input.GetAxis("Mouse Y") * ROTATION_X_MOUSE);

                    m_rotationX += (addRotationX * Time.deltaTime);
                }
                else if(m_rotationX >= 30)
                {
                    m_rotationX = 29;
                }
                else if(m_rotationX <= -50)
                {
                    m_rotationX = -49;
                }
            }
            transform.rotation = Quaternion.Euler(0, m_rotationY, 0);
        }

        bool shiftFlag = false;

        Vector3 addPosition = Vector3.zero;
        {                                                                           // 앞뒤
            Vector3 vecInput = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
            if (vecInput.z > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
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
            
            //if(isGrounded())
            
            if (Input.GetButtonDown("Jump"))
            {
                jumpCount++;

                if (jumpCount >= 2)
                {
                    jumpFlag = false;
                }
                else
                {
                    jumpFlag = true;
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.AddForce(new Vector3(0f, 5f, 0), ForceMode.VelocityChange); // 무게 고려 x 속도량, impact : 무게 고려
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
            
            animator.SetBool("Jump", jumpFlag);
            
            
        }
    }

    bool isGrounded()
    {
        //GameObject foot = GameObject.FindGameObjectWithTag("LeftToe");
        GameObject foot1 = GameObject.Find("Character1_LeftToeBase");
        GameObject foot2 = GameObject.Find("Character1_RightToeBase");
        return Physics.Raycast(foot1.transform.position,Vector3.down,0.2f) || Physics.Raycast(foot2.transform.position, Vector3.down, 0.2f);    // 레이저를 쏴서 0.2f 사이에 collision이 있다면.
    }

    private void OnCollisionStay(Collision collision)
    {
        jumpFlag = false;
        jumpCount = 0;
        Animator animator = playerObject.GetComponent<Animator>();
        animator.SetBool("Jump", jumpFlag);
    }

}
