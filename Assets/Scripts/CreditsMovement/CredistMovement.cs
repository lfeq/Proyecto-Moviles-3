using UnityEngine;

public class CredistMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed = 1;

    private void Update() {
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }
}