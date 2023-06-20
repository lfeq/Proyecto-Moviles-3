using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelTwoObstacle : MonoBehaviour {
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float angle = 45.0f;
    [SerializeField] private float distance = 2.0f;
    [SerializeField] private GameObject obstaclePos;
    private float timer = 0; 


    void Update() {
        timer += Time.deltaTime;
        float x = Mathf.Sin(timer * speed) * distance ;
        transform.position = new Vector3(transform.position.x + x, 2f, transform.position.z);
        //transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * speed) * angle);
    }

    //public Transform[] path = new Transform[10];
    //public float speed = 5.0f;
    //public float reachDist = 1.0f;
    //public int currentPoint = 0;

    //void Update() {
    //    if (currentPoint < path.Length) {
    //        float dist = Vector3.Distance(transform.position, path[currentPoint].position);
    //        transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

    //        if (dist <= reachDist) {
    //            currentPoint++;
    //        }

    //        if (currentPoint >= path.Length) {
    //            currentPoint = 0;
    //        }
    //    }



    //}
}
