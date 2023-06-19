using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObstacle : MonoBehaviour
{
    //public float speed = 1.0f;
    //public Transform target;
    //public Transform start;
    //public float reverseSpeed = 1.0f;
    //public float tolerance = 0.1f;

    //void Update() {
    //    float step = speed * Time.deltaTime;
    //    transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    //    if (Vector3.Distance(transform.position, target.position) < tolerance) {
    //        float reverseStep = reverseSpeed * Time.deltaTime;
    //        transform.position = Vector3.MoveTowards(transform.position, start.position, reverseStep);
    //        Debug.Log("hace el if");
    //    }
    //}

    public Transform target;
    public Transform start;
    public float speed = 1.0f;
    public float tolerance = 0.1f;

    private bool hasArrived = false;

    void Update() {
        if (!hasArrived) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position == target.position) {
                hasArrived = true;
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
            if (transform.position == start.position) {
                hasArrived = false;
            }
        }
    }
}
