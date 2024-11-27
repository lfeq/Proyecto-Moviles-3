using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMObstaclesLevelTwo : MonoBehaviour
{
    public Transform start; 
    public Transform target; 
    public float speed = 2f;
    private sphereStates currentState; 
    private Vector3 currentDest; 

    private void Update() {
        switch (currentState) {
            case sphereStates.Standing:
                break;
            case sphereStates.MovingToTarget:
                movingOnX(currentDest, sphereStates.MovingToStart);
                break;
            case sphereStates.MovingToStart:
                movingOnX(currentDest, sphereStates.MovingToTarget);
                break;
        }
    }

    public void changeObstacleState(sphereStates newState) {
        if (currentState == newState) {
            return;
        } 
        currentState = newState; 
        switch (currentState) {
            case sphereStates.Standing:               
                break;
            case sphereStates.MovingToTarget:
                currentDest = target.position; 
                break;
            case sphereStates.MovingToStart:
                currentDest = start.position; 
                break;
        }
    }

    private void movingOnX(Vector3 destination, sphereStates nextState) {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, destination) < 0.1f) {
            changeObstacleState(nextState);
        }
    }
}
public enum sphereStates {
    Standing,          
    MovingToTarget, 
    MovingToStart   
}
