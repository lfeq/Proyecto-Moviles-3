using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public void checkTimeOflevel() {
        float currentTime = LevelManager.instance.getCurrentTime(); 
        float totalTime = LevelManager.instance.getGameTimeInSeconds();
        if (!levelmodel.halfOfTimeReached && currentTime <= totalTime / 2) {
            levelmodel.setHalfOfTime(true);
            interfaceLevel.showTimeofLvlText(); 
        }
    }
}
