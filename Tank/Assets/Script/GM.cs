using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public static GM instance;
    public GameObject tank1;
    public GameObject tank2;
    Camera[] cameras;
    Camera camera1;
    Camera camera2;
    float time;

    bool selected;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        
        tank1 = Instantiate(tank1, new Vector3(26f, 0, 46f), Quaternion.Euler(0, 90f, 0));
        tank2 = Instantiate(tank2, new Vector3(78f, 0, 46f), Quaternion.Euler(0, -90f, 0));
        tank1.GetComponent<tank>().enabled = true;
        tank2.GetComponent<tank>().enabled = false;
        camera1 = tank1.transform.FindChild("Body").gameObject.GetComponentInParent<Camera>();
        camera2 = tank2.transform.FindChild("Body").gameObject.GetComponentInParent<Camera>();
       // camera1.enabled = true;
       // camera2.enabled = false;
       // time = 30;
        selected = false;
        camera1.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time < 0)
        {
            
            time = 30;

            if (selected)
            {
                tank1.GetComponent<tank>().enabled = true;
                tank2.GetComponent<tank>().enabled = false;
                camera1.enabled = true;
                camera2.enabled = false;
            }
            else
            {
                tank1.GetComponent<tank>().enabled = false;
                tank2.GetComponent<tank>().enabled = true;
                camera1.enabled = false;
                camera2.enabled = true;
            }
            selected = !selected;
        }
    }

    
}
