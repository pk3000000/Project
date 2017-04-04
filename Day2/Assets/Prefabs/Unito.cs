using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unito : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rd = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.W))
        {
            rd.AddForce(Vector3.forward * 300 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            Physics.gravity = Vector3.zero; // Vector3.up
        }
    }
}
