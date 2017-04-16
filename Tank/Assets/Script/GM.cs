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

        tank1.transform.position = new Vector3(26f, 0, 46f);
        tank1.transform.rotation = Quaternion.Euler(0, 90f, 0);
        tank2.transform.position = new Vector3(78f, 0, 46f);
        tank2.transform.rotation = Quaternion.Euler(0, -90f, 0);
       // tank2 = Instantiate(tank1, new Vector3(26f, 0, 46f), Quaternion.Euler(0, 90f, 0));
        //tank1 = Instantiate(tank1, new Vector3(78f, 0, 46f), Quaternion.Euler(0, -90f, 0));
        cameras = Camera.allCameras;
        //camera1 = tank1.transform.FindChild("Body").GetComponent<Camera>();
        //camera2 = tank2.transform.FindChild("Body").GetComponent<Camera>();
        camera1 = cameras[1];
        camera2 = cameras[2];
        // camera1.enabled = true;
       // camera2.enabled = false;
       // time = 30;
        selected = true;
        // camera1.enabled = true;
        Camera.main.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(time < 0)
        {
            
            time = 10;

            if (selected)
            {
                tank1.GetComponent<tank>().enabled = true;
                tank2.GetComponent<tank>().enabled = false;
                camera1.enabled = true;
                camera2.enabled = false;
            }
            else
            {
                tank2.GetComponent<tank>().enabled = true;
                tank1.GetComponent<tank>().enabled = false;
                camera2.enabled = true;
                camera1.enabled = false;
               
            }
            selected = !selected;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    
}
