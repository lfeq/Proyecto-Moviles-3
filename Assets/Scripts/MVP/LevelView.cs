using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelView : MonoBehaviour, InterfaceLevel
{
    [SerializeField] private TextMeshProUGUI halfText;
    private LevelPresenter levelPresenter;

    private void Start() {
        LevelModel model = new LevelModel();
        levelPresenter = new LevelPresenter(model, this);
        halfText.enabled = false; 
    }

    public void showHalfText() {
        halfText.enabled = true;
        StartCoroutine(hideHalfText());
    }

    private IEnumerator hideHalfText() {
        yield return new WaitForSeconds(5f);
        halfText.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            levelPresenter.playerIsOnHalfOfLevel();
        }
    }
}
