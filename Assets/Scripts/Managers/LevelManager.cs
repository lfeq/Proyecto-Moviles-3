using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    [SerializeField] private string nextLevelName;
    [SerializeField] private GameObject playerSpawnPoint;
    //public GameObject spawnPoint;
    [SerializeField] private float gameTimeInSeconds;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private CinemachineVirtualCamera playerFollowCamera, ragdollFollowCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup gameOverCanvasGroup;
    [SerializeField] private UnityEvent outOfTimeEvent;
    [SerializeField] private float movementSpeed, jumpForce;
    [SerializeField] private AudioClip gameplayMusic;
    //[SerializeField] private TextMeshProUGUI halfOfTheTimeText;
   // private bool isHalfOfTheTimeTextShowed = false;
    private float m_currentTime;
    private float slowMoTime = 0.3f;

    private void Awake() {
        if (FindObjectOfType<LevelManager>() != null &&
          FindObjectOfType<LevelManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        if (PlayerManager.instance == null) {
            Instantiate(player);
        }
        
    }

    private void Start() {
        Time.timeScale = 1f;
        GameManager.instance.changeGameState(GameState.Playing);
        if (PlayerManager.instance == null) {
            Instantiate(player);
        }
        PlayerManager.instance.transform.position = playerSpawnPoint.transform.position;
        PlayerManager.instance.gameObject.SetActive(true);
        PlayerManager.instance.changePlayerState(PlayerState.None);
        playerFollowCamera.Follow = PlayerManager.instance.getShoulders();
        m_currentTime = gameTimeInSeconds;
        gameOverCanvasGroup.alpha = 0;
        gameOverCanvasGroup.interactable = false;
        PlayerController.instance.setSpeed(movementSpeed);
        PlayerController.instance.setJumpForce(jumpForce);
        AudioManager.instance.playGameplayMusic();
        //halfOfTheTimeText.gameObject.SetActive(false);
    }

    private void Update() {
        m_currentTime -= Time.deltaTime;
        updateTimerText();
        //if(!isHalfOfTheTimeTextShowed && m_currentTime <= gameTimeInSeconds/2) {
        //    showHalfTimeMessage();
        //}
        if (m_currentTime <= 0) {
            outOfTimeEvent.Invoke();
        }
    }

    //private void showHalfTimeMessage() {
    //    halfOfTheTimeText.gameObject.SetActive(true);
    //    StartCoroutine(hideHalfTimeMessage());
    //}

    //private IEnumerator hideHalfTimeMessage() {
    //    yield return new WaitForSeconds(3f);
    //    halfOfTheTimeText.gameObject.SetActive(false);
    //}

    public void playerIsDead() {
        GameManager.instance.changeGameState(GameState.GameOver);
        Time.timeScale = slowMoTime;
        playerFollowCamera.gameObject.SetActive(false);
        ragdollFollowCamera.gameObject.SetActive(true);
        ragdollFollowCamera.LookAt = RagDollManager.instance.getTarget();
        gameOverCanvasGroup.alpha = 1;
        gameOverCanvasGroup.interactable = true;
    }

    public void loadMainMenu() {
        GameManager.instance.loadMainMenu();
    }

    public void restartLevel() {
        GameManager.instance.restartLevel();
       
    }

    public void endLevel() {
        GameManager.instance.setNewLevelName(nextLevelName);
        GameManager.instance.changeGameState(GameState.LoadLevel);
    }

    private void updateTimerText() {
        int minutes = Mathf.FloorToInt(m_currentTime / 60f);
        int seconds = Mathf.FloorToInt(m_currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((m_currentTime * 100f) % 100f);
        string timerString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timerText.text = timerString;
    }
    public float getCurrentTime() {
        return m_currentTime;
    }
    public float getGameTimeInSeconds() {
        return gameTimeInSeconds;
    }
}