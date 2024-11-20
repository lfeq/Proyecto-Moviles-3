using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObstacle : MonoBehaviour {
    //public Transform target;
    //public Transform start;
    //public float speed = 1.0f;
    //public float tolerance = 0.1f;

    //private bool hasArrived = false;

    //void Update() {
    //    if (!hasArrived) {
    //        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    //        if (transform.position == target.position) {
    //            hasArrived = true;
    //        }
    //    } else {
    //        transform.position = Vector3.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
    //        if (transform.position == start.position) {
    //            hasArrived = false;
    //        }
    //    }
    //}

    public Transform target;
    public Transform start;
    public float speed = 1.0f;
    public float tolerance = 1f;
    private bool hasArrived = false;

    void FixedUpdate() {
        if (!hasArrived) {
            GetComponent<Rigidbody>().velocity = (target.position - transform.position).normalized * speed;
            if (Vector3.Distance(transform.position, target.position) < tolerance) {
                hasArrived = true;
            }
        } else {
            GetComponent<Rigidbody>().velocity = (start.position - transform.position).normalized * speed;
            if (Vector3.Distance(transform.position, start.position) < tolerance) {
                hasArrived = false;
            }
        }
    }

}
