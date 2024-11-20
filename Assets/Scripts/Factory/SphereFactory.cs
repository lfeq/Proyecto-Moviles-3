using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFactory : Factory
{
    [SerializeField] private GameObject spherePrefab;
    public Obstacle createObstSphere() {
        if (spherePrefab == null) {
            Debug.LogError("no hay prefab asignado para Snowball");
            return null;
        }
        Sphere newSphere = Instantiate(spherePrefab).GetComponent<Sphere>();
        if (newSphere == null) {
            Debug.LogError("el prefab no tiene un componente Snowball");
        }
        Debug.Log("snowball creada correctamente en SnowBallFactory");
        return newSphere;
    }
}
