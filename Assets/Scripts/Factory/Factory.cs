using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Factory :  MonoBehaviour
{
    //aqui van todas mis factory
    public SnowBallFactory snowBallFactory;
    //public abstract Obstacle createObst();

    
    private void Awake() {
        snowBallFactory = FindObjectOfType<SnowBallFactory>();
    }
    public Obstacle createObstacle() {
        if (snowBallFactory == null) {
            Debug.LogError("snowBallFactory no está asignada en Factory");
            return null;
        }

        return (Snowball)snowBallFactory.createObst();
    }
    public Snowball creeateSnowball()
    {
        return (Snowball)snowBallFactory.createObst();
    }
}



