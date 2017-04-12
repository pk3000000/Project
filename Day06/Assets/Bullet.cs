using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private static readonly float bulletMoveSpeed = 50.0f;
    public GameObject hitEffectPrefab = null;
    Rigidbody rb;
    Vector3 vecAddPos;
    Vector3 dir;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        dir = Vector3.zero;
        Camera[] subCamera = Camera.allCameras;
        dir = subCamera[0].transform.forward;
        vecAddPos = (dir * bulletMoveSpeed);
        rb.AddForce(vecAddPos,ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update () {
        //transform.Translate(transform.forward * Time.deltaTime);
        //rb.AddForce(vecAddPos,ForceMode.VelocityChange);
        //transform.position += ((vecAddPos)*Time.deltaTime);

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
