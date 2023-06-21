using UnityEngine;

public class FinishZone : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            LevelManager.instance.endLevel();
        }
    }
}