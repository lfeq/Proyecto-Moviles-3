using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLevelThreeFactory : Factory, ObstaclesInterface {
    [SerializeField] private GameObject logLevelThreePrefab;
    public Obstacle createObstLogLvlThree() {
        if (logLevelThreePrefab == null) {
            Debug.LogError("no hay prefab asignado para log");
            return null;
        }
        LogLevelThree newLog = Instantiate(logLevelThreePrefab).GetComponent<LogLevelThree>();
        if (newLog == null) {
            Debug.LogError("el prefab no tiene un componente log");
        }
        Debug.Log("snowball creada correctamente en LogFactory");
        return newLog;
    }
}
