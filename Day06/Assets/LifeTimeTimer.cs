using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeTimer : MonoBehaviour {

    public float fTimeLimit = 1.0f;
    private float m_fTimeLeft = 0f; // 남은 생존 시간

    private void Awake() // start 전에 호출
    {
        m_fTimeLeft = fTimeLimit;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        m_fTimeLeft -= Time.deltaTime;
        if(m_fTimeLeft < 0)
        {
            Destroy(gameObject);
        }
	}
}
