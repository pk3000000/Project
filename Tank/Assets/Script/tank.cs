using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour {

    public int HP;

    float horizontal;
    float vertical;

    readonly float HOR_LEFT = -10f;
    readonly float HOR_RIGHT = 10f;
    readonly float VER_UP = 10f;
    readonly float VER_DOWN = -10f;

    Camera tankView;

    GameObject barrel;
    public GameObject bulletObject;
    GameObject cloneBullet;

    CharacterController con;

    float angle;
    float bulletSpeed;
    private float rotationX = 0f;
    Rigidbody brb;

    Vector3 moveCalc;

    // Use this for initialization
    void Start () {
        barrel = transform.FindChild("Barrel").gameObject;//GameObject.Find("Barrel");
        con = GetComponent<CharacterController>();
        bulletSpeed = 0;
        moveCalc = Vector3.zero;
   	}
	
	// Update is called once per frame
	void Update () {
        moveTank();
        Fire();
    }

    private void moveTank()
    {
        moveCalc = Vector3.zero;

        if(con.isGrounded)
        {
            moveCalc = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveCalc = transform.TransformDirection(moveCalc);
            moveCalc *= 10f;
        }

        //moveCalc.y -= 20f * Time.deltaTime;
        
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Horizontal")*10f, 0);
        
        con.SimpleMove(moveCalc);

        if (Input.GetKey(KeyCode.O))
        {
            barrel.transform.eulerAngles = new Vector3(Mathf.LerpAngle(barrel.transform.eulerAngles.x, 20f, Time.deltaTime),
                barrel.transform.eulerAngles.y, barrel.transform.eulerAngles.z);
        }

        if (Input.GetKey(KeyCode.P))
        {
            barrel.transform.eulerAngles = new Vector3(Mathf.LerpAngle(barrel.transform.eulerAngles.x, 90f, Time.deltaTime),
                barrel.transform.eulerAngles.y, barrel.transform.eulerAngles.z);
        }
    }

    private void Fire()
    {
        if(Input.GetButton("Fire1"))
        {
            bulletSpeed += 100f * Time.deltaTime;

            if (bulletSpeed > 100f)
            {
                bulletSpeed = 100f;
            }
        }
        if(Input.GetButtonUp("Fire1"))
        {
            cloneBullet = Instantiate(bulletObject, barrel.transform.position + barrel.transform.up, barrel.transform.rotation);
            brb = cloneBullet.GetComponent<Rigidbody>();
            brb.AddForce(cloneBullet.transform.up * bulletSpeed, ForceMode.VelocityChange);
            bulletSpeed = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            HP -= 20;

            if(HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
