using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;

    private void Awake() {
        if (FindObjectOfType<MenuManager>() != null &&
           FindObjectOfType<MenuManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start() {
        GameManager.instance.changeGameState(GameState.MainMenu);
    }

    public void startGame() {
        GameManager.instance.setNewLevelName("Level1");
        GameManager.instance.changeGameState(GameState.LoadLevel);
    }

    public void exitGame() {
        GameManager.instance.changeGameState(GameState.QuitGame);
    }
}