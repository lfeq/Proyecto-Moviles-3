using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private string m_newLevel;
    private GameState m_gameState;

    private void Awake() {
        if (FindObjectOfType<GameManager>() != null &&
           FindObjectOfType<GameManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void changeGameState(GameState newGameState) {
        if (m_gameState == newGameState) {
            return;
        }
        m_gameState = newGameState;
        switch (m_gameState) {
            case GameState.None:
                break;
            case GameState.LoadMainMenu:
                loadMainMenu();
                break;
            case GameState.MainMenu:
                break;
            case GameState.LoadLevel:
                nextLevel();
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                //gameOver();
                //StartCoroutine(resetLevel());
                break;
            case GameState.Win:
                finalCredits();
                break;
            case GameState.QuitGame:
                break;
            case GameState.RestartLevel:
                restartLevel();
                break;
            default:
                throw new UnityException("null Game State");
        }
    }

    public void changeGameStateInEditor(string t_newState) {
        changeGameState((GameState)System.Enum.Parse(typeof(GameState), t_newState));
    }

    public void startGame() {
        changeGameState(GameState.Playing);
    }

    public void gameOver() {
        changeGameState(GameState.GameOver);
    }

    public IEnumerator resetLevel() {
        yield return new WaitForSeconds(3);
        restartLevel();
    }

    public void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameState getGameState() {
        return m_gameState;
    }

    public void setNewLevelName(string t_newLevel) {
        m_newLevel = t_newLevel;
    }

    public void loadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator loadNextLevel() {
        yield return new WaitForSeconds(5f);
        nextLevel();
    }

    private void nextLevel() {
        SceneManager.LoadScene(m_newLevel);
    }

    private void finalCredits() {
    }
}

public enum GameState {
    None,
    LoadMainMenu,
    MainMenu,
    LoadLevel,
    Playing,
    GameOver,
    Win,
    QuitGame,
    RestartLevel
}