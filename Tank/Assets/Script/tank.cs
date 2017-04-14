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

    float angle;
    float bulletSpeed;
    private float rotationX = 0f;
    Rigidbody brb;

    // Use this for initialization
    void Start () {
        barrel = GameObject.Find("Barrel");

        bulletSpeed = 0;
        
   	}
	
	// Update is called once per frame
	void Update () {
        moveTank();
        Fire();
    }

    private void moveTank()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = HOR_LEFT;
            transform.rotation *= Quaternion.Euler(0, horizontal, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = HOR_RIGHT;
            transform.rotation *= Quaternion.Euler(0, horizontal, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical = VER_UP;
            transform.position += transform.forward * vertical * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = VER_DOWN;
            transform.position += transform.forward * vertical * Time.deltaTime;
        }
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
            bulletSpeed += 50f * Time.deltaTime;

            if (bulletSpeed > 50f)
            {
                bulletSpeed = 50f;
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
