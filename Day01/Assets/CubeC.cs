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
            abc -= 0.01f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            abc += 0.01f;
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            abc = 0.0f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            abc = 0.0f;
        }

        Debug.Log(Input.mousePosition);

        // Input.GetKeyDown() // 한번
        // Input.GetKeyUp()   // 한번
    }
}
