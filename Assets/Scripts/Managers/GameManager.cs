using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject nextLevelI, youLoseI;
    [SerializeField] GameObject mainMenuPanel, gameOverPanel, credistPanel;
    private string m_newLevel;
    GameState m_gameState;

    private void Awake() {
        if (FindObjectOfType<GameManager>() != null &&
           FindObjectOfType<GameManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this; 
    }
    void Start()
    {
       
    }

    public void changeGameState(GameState newGameState) {
        if(m_gameState == newGameState) {
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
                StartCoroutine(loadNextLevel());
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
        youLoseI.SetActive(true);
    }
    public IEnumerator resetLevel() {
        yield return new WaitForSeconds(3);
        restartGame();
    }
    public void restartGame() {
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void finalCredits() {
        credistPanel.SetActive(true);
    }
}

public enum GameState{
    None,
    LoadMainMenu,
    MainMenu,
    LoadLevel,
    Playing,
    GameOver,
    Win
}