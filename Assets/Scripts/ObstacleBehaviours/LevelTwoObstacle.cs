using UnityEngine;

public class LevelTwoObstacle : MonoBehaviour {
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float distance = 2.0f;
    [SerializeField] private GameObject obstaclePos;

    private void Update() {
        float x = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(transform.position.x + x, 2f, transform.position.z);
        //transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * speed) * angle);
    }
}