using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    private LevelModel levelmodel;
    private InterfaceLevel interfaceLevel;

    public LevelPresenter(LevelModel model, InterfaceLevel view) {
        this.levelmodel = model;
        this.interfaceLevel = view;
    }
    public void playerIsOnHalfOfLevel() {
        levelmodel.setHalfOfTheLevel(true);
        interfaceLevel.showHalfText();
    }
}
