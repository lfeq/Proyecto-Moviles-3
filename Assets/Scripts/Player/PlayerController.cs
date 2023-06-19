using System;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public static PlayerController instance;
    
    [SerializeField] private float speed, jumpForce, footRadius;
    [SerializeField] private Transform footPosition;
    [SerializeField] private LayerMask whatIsGround;
    
    private Rigidbody m_rb;
    private bool m_isGrounded;
    private Animator m_animator;

    private void Awake() {
        if (FindObjectOfType<PlayerController>() != null &&
            FindObjectOfType<PlayerController>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start() {
        m_rb = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            jump();
        }
    }

    private void FixedUpdate() {
        m_isGrounded = Physics.CheckSphere(footPosition.position, footRadius, whatIsGround) &&
                       m_rb.velocity.y < 1f;
        horizontalMovement();
        verticalMovement();
    }

    private void horizontalMovement() {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        m_animator.SetFloat("MoveX", movementX);
        m_animator.SetFloat("MoveY", movementY);
        Vector3 inputMovement = new Vector3(movementX, 0, movementY);
        inputMovement.Normalize();
        Vector3 worldMovement = transform.TransformDirection(inputMovement);
        Vector3 velocity = worldMovement * speed;
        velocity.y = m_rb.velocity.y;
        m_rb.velocity = velocity;
        if (m_isGrounded) {
            if (PlayerManager.instance.getPlayerState() == PlayerState.FreeFall ||
                PlayerManager.instance.getPlayerState() == PlayerState.JumpFall) {
                PlayerManager.instance.changePlayerSate(PlayerState.Landing);
            }
            else {
                if (movementX != 0 || movementY != 0) {
                    PlayerManager.instance.changePlayerSate(PlayerState.Running);
                }
                else if (inputMovement == Vector3.zero) {
                    PlayerManager.instance.changePlayerSate(PlayerState.Idle);
                }
            }
        }
    }
    
    private void verticalMovement() {
        if (m_isGrounded) {
            return;
        }
        if (m_rb.velocity.y >= 1f) {
            PlayerManager.instance.changePlayerSate(PlayerState.Jump);
        } else if (m_rb.velocity.y < -0.1f) {
            PlayerManager.instance.changePlayerSate(PlayerState.FreeFall);
            //m_animator.SetFloat("falling", -1);
        }
    }

    private void jump() {
        if (!m_isGrounded) {
            return;
        }
        m_rb.velocity = new Vector2(m_rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(footPosition.position, footRadius);
    }
}