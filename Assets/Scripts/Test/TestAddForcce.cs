using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddForcce : MonoBehaviour
{
    public Rigidbody rb;
    private void Start() {
        rb.AddForce(new Vector3(0,200,1),ForceMode.Impulse);
    }


}
