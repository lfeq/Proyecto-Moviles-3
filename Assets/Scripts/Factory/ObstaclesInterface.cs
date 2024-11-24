using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObstaclesInterface 
{
    public Obstacle createObst(Obstacle obstacle);
    public Snowball createSnowBall();
    public Sphere createSphere();
    public Log createLog();
    public LogLevelThree createLogLevelThree();
 
}
