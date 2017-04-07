using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    Animator ani;
    GameObject hitObject;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray;
        RaycastHit hit;

        ani.SetBool("Touch", false);

        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, 100))
            {
                hitObject = hit.collider.gameObject;
                if(hitObject.gameObject.tag == "Head")
                {
                    ani.SetBool("Touch", true);
                }
                else
                {
                    Debug.Log("Hit");
                }
            }
        }
	}
}
