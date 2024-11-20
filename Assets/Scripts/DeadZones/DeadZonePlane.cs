using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZonePlane : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("moriste");
            //LevelManager.instance.playerIsDead();
            PlayerManager.instance.changePlayerState(PlayerState.Dead);
            LevelManager.instance.playerIsDead();

        }
    }
}
