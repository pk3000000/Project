using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CphereControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.F))
        {
            GameObject go = GameObject.Find("Cube") as GameObject;
            go.GetComponent<CubeControl>().bigSize();
        }
	}
}
