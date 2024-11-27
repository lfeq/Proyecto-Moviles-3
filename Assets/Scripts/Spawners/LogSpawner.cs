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
            Debug.LogWarning("esta al principio");
            Log logInstance = obstaclesInterface.createLog(); 
            if (logInstance != null) {
                logInstance.transform.position = startPositions[i].position;  
                FSMObstaclesLevelTwo obstacleLvlTwoFSMInstance = logInstance.GetComponent<FSMObstaclesLevelTwo>();  
                if (obstacleLvlTwoFSMInstance != null) {
                    Debug.LogWarning("esta aqui");
                    obstacleLvlTwoFSMInstance.start = createEmptyTransforms(startPositions[i].position, "start" + i);
                    obstacleLvlTwoFSMInstance.target = createEmptyTransforms(targetPositions[i].position, "target" + i);                                       
                    obstacleLvlTwoFSMInstance.changeObstacleState(sphereStates.MovingToTarget);
                    if (obstacleLvlTwoFSMInstance.start != null && obstacleLvlTwoFSMInstance.target != null) { 
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