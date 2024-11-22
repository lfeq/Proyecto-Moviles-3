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
        //if (startPositions.Count != targetPositions.Count) {
        //    return;
        //}
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < startPositions.Count; i++) {
            Sphere sphereInstance = obstaclesInterface.createSphere();
            if (sphereInstance != null) {
                sphereInstance.transform.position = startPositions[i].position; 
                TranslateObstacle translateScript = sphereInstance.GetComponent<TranslateObstacle>();
                if (translateScript != null) {
                    translateScript.start = createEmptyTransforms(startPositions[i].position, "StartPoint_" + i);
                    translateScript.target = createEmptyTransforms(targetPositions[i].position, "TargetPoint_" + i);
                    if (translateScript.start != null && translateScript.target != null) {
                        //translateScript.start = translateScript.start;
                        //translateScript.target = translateScript.target;
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
