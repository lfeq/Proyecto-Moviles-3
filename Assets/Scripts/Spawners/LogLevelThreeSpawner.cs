using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLevelThreeSpawner : MonoBehaviour
{
    public ObstaclesInterface obstaclesInterface;
    [SerializeField] private Transform startPosition;

    void Start()
    {
        obstaclesInterface = (ObstaclesInterface)FindObjectOfType<Factory>();
        LogLevelThree loglvlThreeInstance = obstaclesInterface.createLogLevelThree();
        loglvlThreeInstance.transform.position = startPosition.position;
    }

}
