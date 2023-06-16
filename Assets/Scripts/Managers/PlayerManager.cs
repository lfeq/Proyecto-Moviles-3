using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    
    private Animator m_animator;
    private PlayerState m_playerState;

    private void Awake() {
        if (FindObjectOfType<PlayerManager>() != null &&
            FindObjectOfType<PlayerManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start() {
        m_animator = GetComponent<Animator>();
        m_playerState = PlayerState.None;
    }

    public void changePlayerSate(PlayerState t_newSate) {
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
                break;
            case PlayerState.JumpFall:
                m_animator.SetBool("isFalling", true);
                break;
            case PlayerState.FreeFall:
                m_animator.SetBool("isFalling", true);
                break;
            case PlayerState.Landing:
                m_animator.SetBool("isLanding", true);
                print("kandong");
                break;
            case PlayerState.Dead:
                m_animator.SetBool("isDying", true);
                break;
        }
    }

    public PlayerState getPlayerState() {
        return m_playerState;
    }

    private void resetAnimatorParameters() {
        foreach (AnimatorControllerParameter parameter in m_animator.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Bool) {
                m_animator.SetBool(parameter.name, false);
            }
        }
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