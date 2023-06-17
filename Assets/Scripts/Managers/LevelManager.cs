using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;
    [SerializeField] GameObject playerSpawnpoint;
    public bool isDeeadZoneActivated;
    
    private void Awake() {
        instance = this; 
    }
    void Start()
    {
        //player.transform.position = playerSpawnpoint;
    }

    void Update()
    {
        if (isDeeadZoneActivated) {
            //playerGameState(died)
        }
        //if (PlayerManager.instance.isWin) {
        //    GameManager.instance.changeGameState(GameState.LoadLevel);
        //}
    }
}
