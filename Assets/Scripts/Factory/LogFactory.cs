using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogFactory : Factory, ObstaclesInterface {
    [SerializeField] private GameObject logPrefab;
    public Obstacle createObstLog() {
        if (logPrefab == null) {
            Debug.LogError("no hay prefab asignado para log");
            return null;
        }
        Log newLog = Instantiate(logPrefab).GetComponent<Log>();
        if (newLog == null) {
            Debug.LogError("el prefab no tiene un componente log");
        }
        Debug.Log("snowball creada correctamente en LogFactory");
        return newLog;
    }
}
