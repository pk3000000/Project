using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeC : MonoBehaviour {

    public float abc;
    private int bbc;

	// Use this for initialization
	void Start () {
        abc = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetMouseButton(0)) // 누르는 중
        {
            gameObject.transform.rotation *= Quaternion.Euler(10, 0, 0);
            gameObject.transform.position += new Vector3(abc, 0.0f, 0.1f);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetMouseButton(1))
        {
            gameObject.transform.rotation *= Quaternion.Euler(-10, 0, 0);
            gameObject.transform.position += new Vector3(abc, 0.0f, -0.1f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion v3Rotation = Quaternion.Euler(0f, -30f, 0f);
            Vector3 v3Direction = Vector3.forward;
            Vector3 v3RotateDirection = v3Rotation * v3Direction;

            gameObject.transform.position += v3RotateDirection;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion v3Rotation = Quaternion.Euler(0f, 30f, 0f);
            Vector3 v3Direction = Vector3.forward;
            Vector3 v3RotateDirection = v3Rotation * v3Direction;

            gameObject.transform.position += v3RotateDirection;
        }


        Debug.Log(Input.mousePosition);

        // Input.GetKeyDown() // 한번
        // Input.GetKeyUp()   // 한번
    }
}
