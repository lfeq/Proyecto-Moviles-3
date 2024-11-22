using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public ObstaclesInterface obstaclesInterface;
    [SerializeField] private List<Transform> startPositions;
    [SerializeField] private List<Transform> targetPositions;
    private List<Log> logList = new List<Log>();


    private void Start() {
        obstaclesInterface = (ObstaclesInterface)FindObjectOfType<Factory>();
        StartCoroutine(createLogs());
    }
    private IEnumerator createLogs() {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < startPositions.Count; i++) {
            Log logInstance = obstaclesInterface.createLog();
            if (logInstance != null) {
                logInstance.transform.position = startPositions[i].position;
                TranslateObstacle translateScript = logInstance.GetComponent<TranslateObstacle>();
                if (translateScript != null) {
                    translateScript.start = createEmptyTransforms(startPositions[i].position, "StartPoint_" + i);
                    translateScript.target = createEmptyTransforms(targetPositions[i].position, "TargetPoint_" + i);
                    if (translateScript.start != null && translateScript.target != null) {
                        logList.Add(logInstance);
                    }
                }
            }
        }
    }
    private Transform createEmptyTransforms(Vector3 position, string name) {
        GameObject point = new GameObject(name);
        point.transform.position = position;
        return point.transform;
    }
}
