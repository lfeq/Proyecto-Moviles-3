using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollManager : MonoBehaviour {
    [SerializeField] float force = 2;
    [SerializeField]private Rigidbody m_rb;
    
    public void applyForce(Vector3 direction) {
        m_rb.AddForce(direction * force, ForceMode.Impulse);
    }
}

