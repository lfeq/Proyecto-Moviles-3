using System.Collections;
using UnityEngine;

public class RotateLogLevelThree : MonoBehaviour {
    [SerializeField] private float speed = 10;
    [SerializeField] private float dampingFactor = 0.9f;

    private Rigidbody m_rigidBody;
    private bool m_isRotating = false;

    private void Start() {
        m_rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(startSpin());
    }

    private void FixedUpdate() {
        if (!m_isRotating) {
            return;
        }
        float torqueForce = speed / m_rigidBody.inertiaTensor.magnitude;
        m_rigidBody.AddTorque(Vector3.up * torqueForce);
        m_rigidBody.AddTorque(-m_rigidBody.angularVelocity * dampingFactor);
    }

    private IEnumerator startSpin() {
        yield return new WaitForSeconds(2.5f);
        m_isRotating = true;
    }
}