using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Snowball snowballPrefab;

  
    public Obstacle CreateObstacle(string type) {
        switch (type) {
            case "Snowball":
                //return Instantiate(snowballPrefab);
            
            default:
                Debug.LogWarning("Tipo de obstáculo no soportado");
                return null;
        }
    }
}

public abstract class Obstacle {
    public abstract void showObstacle(); 
}

