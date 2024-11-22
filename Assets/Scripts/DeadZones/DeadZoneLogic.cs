using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneLogic : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //Debug.LogWarning("pego con player!!!!!!!!!!!!!!");
            Vector3 collisionDirection = GetComponent<Rigidbody>().velocity.normalized;
            if(collisionDirection == Vector3.zero) {
             collisionDirection = GetComponent<Rigidbody>().angularVelocity.normalized;
            }
            PlayerManager.instance.setVectorDirection(collisionDirection);
            PlayerManager.instance.changePlayerState(PlayerState.Dead);
            //Rigidbody playerRigidBody = other.GetComponent<Rigidbody>();
            //playerRigidBody.AddForce(collisionDirection * 9f, ForceMode.Impulse);
            LevelManager.instance.playerIsDead();
        }
    }
}
