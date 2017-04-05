using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeC : MonoBehaviour {
    
    private Vector3 dir = Vector3.forward;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetMouseButton(0)) // 누르는 중
        {
            //gameObject.transform.rotation *= Quaternion.Euler(10, 0, 0);
            //gameObject.transform.position += new Vector3(0, 0, 0.1f);
            //gameObject.transform.rotation *= Quaternion.Euler(10, 0, 0);
            //gameObject.transform.TransformDirection(Vector3.forward);
            //gameObject.transform.Translate(-1 * gameObject.transform.forward * Time.deltaTime * 2);
            //gameObject.transform.position += gameObject.transform.forward;


            //transform.Rotate(10 * Time.deltaTime, 0, 0);

            //Vector3 forward = transform.forward;
            //Vector3 right = transform.right;
            //Vector3 up = transform.up;
            // Zero out the y component of your forward vector to only get the direction in the X,Z plane
            //forward.y = 0;
            //right.y = 0;
            //Vector3 headingAngle = Quaternion.LookRotation(forward) * new Vector3(1,1,1);

            //if (headingAngle.y > 180f) headingAngle.y -= 360f;

            transform.Rotate(180f * Time.deltaTime, 0,0,Space.Self);
            
            transform.Translate(dir.normalized * 7.0f * Time.deltaTime, Space.World);
            

            //transform.Rotate(transform.TransformDirection(transform.forward).normalized * 10f * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetMouseButton(1))
        {
            //gameObject.transform.rotation *= Quaternion.Euler(-10, 0, 0);
            //gameObject.transform.position += new Vector3(0, 0, -0.1f);
            //gameObject.transform.rotation *= Quaternion.Euler(-10, 0, 0);
            //gameObject.transform.TransformDirection(Vector3.forward);
            //gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * 2);
            //gameObject.transform.position += gameObject.transform.forward;
            //transform.Rotate(transform.local)

            //dir = transform.localPosition;
            // transform.Rotate(dir);


            //transform.Rotate(-10 * Time.deltaTime, 0, 0);
            // transform.localRotation *= Quaternion.Euler(-60f * Time.deltaTime);
            transform.Rotate(-180f * Time.deltaTime, 0, 0, Space.Self);
            
            transform.Translate(dir.normalized * -7.0f * Time.deltaTime, Space.World);
            

            //transform.Rotate(transform.TransformDirection(transform.forward).normalized * (-10f) * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
           // abc = -60;
            dir = Quaternion.Euler(0, -180f * Time.deltaTime, 0) * dir;
            //transform.rotation *= Quaternion.Euler(0, -60 * Time.deltaTime, 0);
            transform.Rotate(new Vector3(0, -180f * Time.deltaTime, 0), Space.World);
            //dir = transform.localPosition;

            //gameObject.transform.Rotate(new Vector3(0, -10, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
           // abc = 60;
            dir = Quaternion.Euler(0, 180f * Time.deltaTime, 0) * dir;
            transform.Rotate(new Vector3(0, 180f * Time.deltaTime, 0), Space.World);
            //transform.Rotate(Vector3.up, 60 * Time.deltaTime);
            //gameObject.transform.Rotate(new Vector3(0, 10, 0));
        }


        Debug.Log(Input.mousePosition);

        // Input.GetKeyDown() // 한번
        // Input.GetKeyUp()   // 한번
    }
}
