using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstTest : MonoBehaviour {

    public GameObject cube = null;

	// Use this for initialization
	void Start () {
        Instantiate(cube);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
