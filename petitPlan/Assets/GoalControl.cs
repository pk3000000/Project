using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalControl : MonoBehaviour {
    private bool is_collided = false;
    public float GOAL_MIN = 5.0f;
    public float GOAL_MAX = 10.0f;

	// Use this for initialization
	void Start () {
        float rnd = Random.Range(GOAL_MIN, GOAL_MAX);
        transform.position = new Vector3(rnd, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
     //   Collision col = gameObject.GetComponent<Collision>();
       if(is_collided)
        {
            
        }
	}

    private void OnCollisionStay(Collision collision)
    {
        is_collided = true;

        Debug.Log("collision");
    }

    private void OnGUI()
    {
        if(is_collided)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 128, 128), "성공");
            //is_collided = false;
        }
    }
}
