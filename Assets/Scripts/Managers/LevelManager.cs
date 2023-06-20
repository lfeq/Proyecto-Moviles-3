using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    [SerializeField] private GameObject playerSpawnPoint;
    [SerializeField] private float gameTimeInSeconds;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject playerFollowCamera, ragdollFollowCamera;
    //public bool isDeadZoneActivated;

    private float m_currentTime;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        GameManager.instance.changeGameState(GameState.Playing);
        m_currentTime = gameTimeInSeconds;
        //player.transform.position = playerSpawnpoint;
    }

    private void Update() {
        m_currentTime -= Time.deltaTime;
        updateTimerText();
    }

    public void playerIsDead() {
        GameManager.instance.changeGameState(GameState.GameOver);
        playerFollowCamera.gameObject.SetActive(false);
        ragdollFollowCamera.gameObject.SetActive(true);
    }

    private void updateTimerText() {
        int minutes = Mathf.FloorToInt(m_currentTime / 60f);
        int seconds = Mathf.FloorToInt(m_currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((m_currentTime * 100f) % 100f);

        string timerString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timerText.text = timerString;
    }
}