using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Log : Obstacle
{
    public IObjectPool<Obstacle> logPool;
    public override void showObstacle() {
        Debug.Log("sostrando snowball");
    }
}
