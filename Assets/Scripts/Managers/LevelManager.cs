using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;
    [SerializeField] GameObject playerSpawnPoint;
    public bool isDeadZoneActivated;
    
    private void Awake() {
        instance = this; 
    }
    void Start()
    {
        GameManager.instance.changeGameState(GameState.Playing);
        //player.transform.position = playerSpawnpoint;
    }

    void Update()
    {
        if (isDeadZoneActivated) {
            //playerGameState(died)
        }
        //if (PlayerManager.instance.isWin) {
        //    GameManager.instance.changeGameState(GameState.LoadLevel);
        //}
    }
}
