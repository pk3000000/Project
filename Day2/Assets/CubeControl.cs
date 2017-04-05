using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
           // transform.Translate(new Vector3(0.0f,0.0f,3.0f*Time.deltaTime));
           transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);
           // transform.Rotate(new Vector3(360*Time.deltaTime,0f,0f));
        }
	}

    public void bigSize()
    {
        transform.localScale = new Vector3(3.0f,3.0f,3.0f);
    }
}
