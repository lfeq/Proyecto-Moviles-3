using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Factory :  MonoBehaviour, ObstaclesInterface
{
    //aqui van todas mis factory
    public SnowBallFactory snowBallFactory;
    public SphereFactory sphereFactory;
    public LogFactory logFactory;
    public LogLevelThreeFactory logLvlThreeFactory;
    private void Awake() {
        snowBallFactory = FindObjectOfType<SnowBallFactory>();
        sphereFactory = FindObjectOfType<SphereFactory>();
        logFactory = FindObjectOfType<LogFactory>();
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

    public Log createLog() {
        Debug.LogWarning("estoy en factory main");
        return (Log)logFactory.createObstLog();
    }

    public LogLevelThree createLogLevelThree() {
        Debug.LogWarning("estoy en factory main");
        return (LogLevelThree)logLvlThreeFactory.createObstLogLvlThree();
    }
}



