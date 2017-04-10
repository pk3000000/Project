using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private static readonly float bulletMoveSpeed = 10.0f;
    public GameObject hitEffectPrefab = null;
    
    Vector3 vecAddPos;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        vecAddPos = (Vector3.forward * bulletMoveSpeed);
        transform.position += ((transform.rotation * vecAddPos)*Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (null != hitEffectPrefab)
        {
            Instantiate(hitEffectPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
