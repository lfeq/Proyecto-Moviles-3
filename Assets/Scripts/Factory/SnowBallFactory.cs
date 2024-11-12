using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallFactory : MonoBehaviour,ObstaclesInterface
{

    [SerializeField] private GameObject snowballPrefab;  
    public Obstacle createObst() {
        if(snowballPrefab == null) {
            Debug.LogError("no hay prefab asignado");
        }
        Snowball newSnowball = Instantiate(snowballPrefab).GetComponent<Snowball>();
        Debug.LogWarning("se creo en factrory de snowBalls");
        return newSnowball;
    }
}
