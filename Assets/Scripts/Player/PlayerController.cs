using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed;
    
    private Rigidbody m_rb;

    private void Start() {
        m_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        Vector3 vectorMovement = new Vector3(movementX, 0, movementY).normalized * speed;
        m_rb.velocity = new Vector3(vectorMovement.x, m_rb.velocity.y, vectorMovement.z);
    }
}