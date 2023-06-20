using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLogLevelThree : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    void Start() {
        //rb = GetComponent<Rigidbody>();
        //transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    void FixedUpdate() {
        //float x = Time.deltaTime;
        gameObject.transform.rotation= Quaternion.Euler(0,90,0);
        //rb.AddForce(transform.up * speed);
    }
}
