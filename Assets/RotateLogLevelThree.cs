using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLogLevelThree : MonoBehaviour {
    private Rigidbody m_rigidBody;
    [SerializeField] private float speed = 10;
    [SerializeField] private float dampingFactor = 0.9f;

    void Start() {
        m_rigidBody = GetComponent<Rigidbody>();
    }
    //void FixedUpdate() {
    //    m_rigidBody.AddTorque(Vector3.up * 5);
    //}


    void FixedUpdate() {
        float torqueForce = speed / m_rigidBody.inertiaTensor.magnitude;
        m_rigidBody.AddTorque(Vector3.up * torqueForce);
        m_rigidBody.AddTorque(-m_rigidBody.angularVelocity * dampingFactor);
    }
}
