using UnityEngine;

public class CreditsManager : MonoBehaviour {

    public void returnToMenu() {
        GameManager.instance.changeGameState(GameState.MainMenu);
    }
}