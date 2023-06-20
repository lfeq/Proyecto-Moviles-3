using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;

    [SerializeField] private GameObject ragdollPrefab;
    [SerializeField] private Transform shoulders;

    private Animator m_animator;
    private PlayerState m_playerState;
    private Rigidbody[] rigidBodies;
    private Rigidbody m_rigidBody;
    private Vector3 m_coliisionDirection;

    private void Awake() {
        if (FindObjectOfType<PlayerManager>() != null &&
            FindObjectOfType<PlayerManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start() {
        m_animator = GetComponent<Animator>();
        m_playerState = PlayerState.None;
        m_rigidBody = GetComponent<Rigidbody>();
        rigidBodies = transform.GetComponentsInChildren<Rigidbody>();
        setEnabled(true);
    }

    public void changePlayerState(PlayerState t_newSate) {
        if (m_playerState == t_newSate) {
            return;
        }
        resetAnimatorParameters();
        m_playerState = t_newSate;
        switch (m_playerState) {
            case PlayerState.None:
                break;
            case PlayerState.Idle:
                m_animator.SetBool("isIdeling", true);
                break;
            case PlayerState.Running:
                m_animator.SetBool("isRunning", true);
                break;
            case PlayerState.Jump:
                m_animator.SetBool("isJumpng", true);
                m_animator.SetFloat("falling", 1);
                break;
            case PlayerState.JumpFall:
                m_animator.SetBool("isFalling", true);
                m_animator.SetFloat("falling", 0);
                break;
            case PlayerState.FreeFall:
                m_animator.SetBool("isFalling", true);
                m_animator.SetFloat("falling", 0);
                break;
            case PlayerState.Landing:
                m_animator.SetBool("isLanding", true);
                m_animator.SetFloat("falling", -1);
                break;
            case PlayerState.Dead:
                m_animator.SetBool("isDying", true);
                activateRagDoll();
                break;
        }
    }

    public PlayerState getPlayerState() {
        return m_playerState;
    }

    public void setVectorDirection(Vector3 coliisonVector) {
        m_coliisionDirection = coliisonVector;
    }

    public Transform getShoulders() {
        return shoulders;
    }

    private void resetAnimatorParameters() {
        foreach (AnimatorControllerParameter parameter in m_animator.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Bool) {
                m_animator.SetBool(parameter.name, false);
            }
        }
    }

    //incia ragdoll Logic
    private void setEnabled(bool isEnabled) {
        bool isFirstElement = true;
        foreach (Rigidbody rigidbody in rigidBodies) {
            if (isFirstElement) {
                isFirstElement = false;
                continue;
            }
            rigidbody.isKinematic = isEnabled;
        }
    }

    private void activateRagDoll() {
        gameObject.SetActive(false);
        GameObject tempRagDoll = Instantiate(ragdollPrefab, transform.position, Quaternion.identity);
        tempRagDoll.GetComponent<RagDollManager>().applyForce(m_coliisionDirection);
    }
}

public enum PlayerState {
    None,
    Idle,
    Running,
    Jump,
    JumpFall,
    FreeFall,
    Dead,
    Landing
}