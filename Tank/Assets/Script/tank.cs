using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour {

    float horizontal;
    float vertical;

    readonly float HOR_LEFT = -10f;
    readonly float HOR_RIGHT = 10f;
    readonly float VER_UP = 10f;
    readonly float VER_DOWN = -10f;

    Camera tankView;

    GameObject barrel;

    float angle;

    private float rotationX = 0f;

    // Use this for initialization
    void Start () {
        Camera[] cameras = Camera.allCameras;
        tankView = cameras[1];
        cameras[1].enabled = true;
        Camera.main.enabled = false;

        barrel = GameObject.Find("Barrel");
	}
	
	// Update is called once per frame
	void Update () {
        moveTank();
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
}
