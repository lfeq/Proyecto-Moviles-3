using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class RagDollTest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody[] rigidBodies;
    
    void Start()
    {
        rigidBodies = transform.GetComponentsInChildren<Rigidbody>();
        setEnabled(false);
    }

    private void setEnabled(bool isEnabled) {
        foreach (Rigidbody rigidbody in rigidBodies) {
            rigidbody.isKinematic = isEnabled;
        }
        animator.enabled = !isEnabled;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) {
            Debug.Log("input espacio");
            setEnabled(true);
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            setEnabled(false);
        }

    }
}
