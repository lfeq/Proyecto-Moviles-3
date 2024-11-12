using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    //aqui van todas mis factory
    public SnowBallFactory snowBallFactory;
    public abstract ObstacleInterface createObstacle();

    private void Awake() {
        snowBallFactory = FindObjectOfType<SnowBallFactory>();
    }

    //public override ObstacleInterface createObstacle(Obstacle obstcle){
    //    return (Snowball)snowBallFactory.createObst();
    //}
    public Snowball creeateSnowball()
    {
        return (Snowball)snowBallFactory.createObst();
    }
}



