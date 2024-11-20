using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Sphere : Obstacle 
{
    public IObjectPool<Obstacle> spherePool;
    public override void showObstacle() {
        Debug.Log("sostrando snowball");
    }
    
}
