using UnityEngine;

public class RagDollManager : MonoBehaviour {
    public static RagDollManager instance;

    [SerializeField] private float force = 2;
    [SerializeField] private Rigidbody m_rb;

    private void Awake() {
        if (FindObjectOfType<RagDollManager>() != null &&
            FindObjectOfType<RagDollManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void applyForce(Vector3 direction) {
        m_rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public Transform getTarget() {
        return m_rb.transform;
    }
}