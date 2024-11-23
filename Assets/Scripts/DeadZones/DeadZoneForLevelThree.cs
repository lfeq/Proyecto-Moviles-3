using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneForLevelThree : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("moriste");
            PlayerManager.instance.changePlayerState(PlayerState.Dead);
            LevelManager.instance.playerIsDead();
        }
    }
}
