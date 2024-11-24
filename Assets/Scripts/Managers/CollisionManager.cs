using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private LevelPresenter levelPresenter;

    public void Initialize(LevelPresenter presenter) {
        levelPresenter = presenter;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            levelPresenter.playerIsOnHalfOfLevel();
        }
    }
}
