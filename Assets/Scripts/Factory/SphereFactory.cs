using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFactory : Factory, ObstaclesInterface
{
    [SerializeField] private GameObject spherePrefab;
    public Obstacle createObstSphere() {
        if (spherePrefab == null) {
            Debug.LogError("no hay prefab asignado para Spehre");
            return null;
        }
        Sphere newSphere = Instantiate(spherePrefab).GetComponent<Sphere>();
        if (newSphere == null) {
            Debug.LogError("el prefab no tiene un componente Sphere");
        }
        Debug.Log("snowball creada correctamente en SpehereFactory");
        return newSphere;
    }
}
