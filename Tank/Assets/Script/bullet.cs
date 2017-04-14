using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    
	// Use this for initialization
	void Start () {

        Destroy(gameObject, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
