using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRootControl : MonoBehaviour {
    public GameObject prefab = null;
    private AudioSource audio;
    public AudioClip jumpSound;
    public Texture2D icon = null;
    public static string mes_text = "게임 아카데미";
    private GameObject go = null;
    // Use this for initialization
    void Start () {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = jumpSound;
        audio.loop = false;
        audio.spatialBlend = 0.0f; // 3D sound 1.0, 0.0
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            go = GameObject.Instantiate(prefab);
            go.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 1.0f, Random.Range(-2.0f, 2.0f));
            audio.Play();
        }
        if(Input.GetMouseButtonDown(1))
        {
            go = GameObject.Find("unito(Clone)");
            GameObject.Destroy(go);
        }
	}

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width/2,64,64,64),icon);
        GUI.Label(new Rect(Screen.width / 2, 128, 128, 32), mes_text);
    }
}
