using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private SnowBallFactory snowBallFactory;

    private void Awake() {
        snowBallFactory = FindObjectOfType<SnowBallFactory>();
    }
    public Snowball creeateSnowball() {
        return (Snowball)snowBallFactory.createObst();
    }
}



