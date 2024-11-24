using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LogLevelThree : Obstacle
{
    public IObjectPool<Obstacle> logPool;
    public override void showObstacle() {
        Debug.Log("sostrando snowball");
    }
}
