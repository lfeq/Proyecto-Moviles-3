using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpheresSpawner : MonoBehaviour
{
    public ObstaclesInterface obstaclesInterface;
    [SerializeField] private List<Vector3> startPositions;
    [SerializeField] private List<Vector3> targetPositions;

    private void Start() {
        createSpheres();
    }
    private void createSpheres() {
        if (startPositions.Count != targetPositions.Count) {
            Debug.LogError("Las listas de posiciones de inicio y destino deben tener la misma cantidad de elementos.");
            return;
        }
        for (int i = 0; i < startPositions.Count; i++) {
            Obstacle sphereInstance = obstaclesInterface.createSphere();
            if (sphereInstance != null) {
                sphereInstance.transform.position = startPositions[i]; 
                TranslateObstacle translateScript = sphereInstance.GetComponent<TranslateObstacle>();
                if (translateScript != null) {
                    translateScript.start = createEmptyTransforms(startPositions[i], "StartPoint_" + i);
                    translateScript.target = createEmptyTransforms(targetPositions[i], "TargetPoint_" + i);
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
