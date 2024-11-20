using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Factory :  MonoBehaviour, ObstaclesInterface
{
    //aqui van todas mis factory
    public SnowBallFactory snowBallFactory;
    public SphereFactory sphereFactory;
    //public abstract Obstacle createObst();

    
    private void Awake() {
        snowBallFactory = FindObjectOfType<SnowBallFactory>();
    }
    public Obstacle createObst(Obstacle obstacle) {
        if (snowBallFactory == null) {
            Debug.LogError("snowBallFactory no está asignada en Factory");
            return null;
        }

        return (Snowball)snowBallFactory.createObst();
    }

    public Snowball createSnowBall() {
        Debug.LogWarning("estoy en factory main");
        return (Snowball)snowBallFactory.createObst();
    }

    public Sphere createSphere() {
        Debug.LogWarning("estoy en factory main");
        return (Sphere)sphereFactory.createObstSphere();
    }
}



