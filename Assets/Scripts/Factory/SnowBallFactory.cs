using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallFactory : Factory,ObstaclesInterface
{

    [SerializeField] private GameObject snowballPrefab;
    //public override Obstacle createObst() {
    //    if(snowballPrefab == null) {
    //        Debug.LogError("no hay prefab asignado");
    //    }
    //    Snowball newSnowball = Instantiate(snowballPrefab).GetComponent<Snowball>();
    //    Debug.LogWarning("se creo en factrory de snowBalls");
    //    return newSnowball;
    //}
    public Obstacle createObst() {
        if (snowballPrefab == null) {
            Debug.LogError("no hay prefab asignado para Snowball");
            return null;
        }
        Snowball newSnowball = Instantiate(snowballPrefab).GetComponent<Snowball>();
        if (newSnowball == null) {
            Debug.LogError("el prefab no tiene un componente Snowball");
        }
        Debug.Log("snowball creada correctamente en SnowBallFactory");
        return newSnowball;
    }
}
