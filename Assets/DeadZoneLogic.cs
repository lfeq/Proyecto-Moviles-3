using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneLogic : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Vector3 collisionDirection = GetComponent<Rigidbody>().velocity.normalized;
            Rigidbody playerRigidBody = other.GetComponent<Rigidbody>();
            playerRigidBody.AddForce(collisionDirection * 9f, ForceMode.Impulse);
            LevelManager.instance.playerIsDead();
            PlayerManager.instance.changePlayerSate(PlayerState.Dead);
        }
    }
}
