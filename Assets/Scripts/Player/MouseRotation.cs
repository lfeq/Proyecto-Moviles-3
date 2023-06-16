using UnityEngine;

public class MouseRotation : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform shoulders;

    void Update() {
        float mouseX = Input.GetAxis("Mouse X");
        shoulders.rotation *= Quaternion.AngleAxis(mouseX * rotationSpeed, Vector3.up);
        if (PlayerManager.instance.getPlayerState() != PlayerState.Idle) {
            transform.rotation = Quaternion.Euler(0, shoulders.rotation.eulerAngles.y, 0);
            shoulders.localEulerAngles = Vector3.zero;
        }
    }
}