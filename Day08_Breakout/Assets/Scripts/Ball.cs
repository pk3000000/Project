using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float ballInitialVelocity = 500f;

    private Rigidbody rb;
    private bool ballInPlay;    // 볼이 플레이 중이냐.

    private void Awake()        // Start 함수 호출 전에 호출
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && ballInPlay==false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, ballInitialVelocity, 0));
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 vac = collision.gameObject.transform.right * 50f + collision.gameObject.transform.up * 50f;
            rb.AddForce(vac);
        }
    }
}
