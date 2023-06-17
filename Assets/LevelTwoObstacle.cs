using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelTwoObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float angle = 45.0f;
    [SerializeField] private float distance = 2.0f;
    [SerializeField] private GameObject obstaclePos;

    
    void Update() {
        float x = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(x, 2f, 2f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(Time.time * speed) * angle);
    }




}
