using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class SpheresSpawner : MonoBehaviour
{
    public ObstaclesInterface obstaclesInterface;
    [SerializeField] private List<Transform> startPositions;
    [SerializeField] private List<Transform> targetPositions;
    private List<Sphere> sphereList = new List<Sphere>();
    

    private void Start() {
        obstaclesInterface = (ObstaclesInterface)FindObjectOfType<Factory>();
        StartCoroutine(createSpheres());
    }
    private IEnumerator createSpheres() {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < startPositions.Count; i++) {
            Debug.LogWarning("esta al principio");
            Sphere sphereInstance = obstaclesInterface.createSphere();
            if (sphereInstance != null) {
                sphereInstance.transform.position = startPositions[i].position;
                FSMObstaclesLevelTwo obstacleLvlTwoFSMInstance = sphereInstance.GetComponent<FSMObstaclesLevelTwo>();
                if (obstacleLvlTwoFSMInstance != null) {
                    Debug.LogWarning("esta aqui");
                    obstacleLvlTwoFSMInstance.start = createEmptyTransforms(startPositions[i].position, "start" + i);
                    obstacleLvlTwoFSMInstance.target = createEmptyTransforms(targetPositions[i].position, "target" + i);
                    obstacleLvlTwoFSMInstance.changeObstacleState(sphereStates.MovingToTarget);
                    if (obstacleLvlTwoFSMInstance.start != null && obstacleLvlTwoFSMInstance.target != null) {
                        sphereList.Add(sphereInstance);
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