using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {
    private float power;
    public float POWERPLUS = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButton(0))
        {
            power += POWERPLUS * Time.deltaTime;
        }
        if(Input.GetMouseButtonUp(0))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(power, power, 0));
            power = 0.0f;
        }
        if(transform.position.y < -5.0 || transform.position.x > 20.0f)
        {
            SceneManager.LoadScene("gameScene");
        }
    }
}
