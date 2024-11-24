using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelView : MonoBehaviour, InterfaceLevel
{
    [SerializeField] private TextMeshProUGUI halfText;
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private CollisionManager collisionManager; 

    private LevelPresenter levelPresenter;

    private void Start() {
        LevelModel model = new LevelModel();
        levelPresenter = new LevelPresenter(model, this);
        if (collisionManager != null) {
            collisionManager.Initialize(levelPresenter);
        }
        halfText.enabled = false; 
        timeTxt.enabled = false;
    }

    private void Update() {
        levelPresenter.checkTimeOflevel();
    }
    public void showTimeofLvlText() {
        timeTxt.enabled = true;
        StartCoroutine(hidetimeText());
    }
    private IEnumerator hidetimeText() {
        yield return new WaitForSeconds(5f);
        timeTxt.enabled = false;
    }
    public void showHalfText() {
        halfText.enabled = true;
        StartCoroutine(hideHalfText());
    }

    private IEnumerator hideHalfText() {
        yield return new WaitForSeconds(5f);
        halfText.enabled = false;
    }
}
