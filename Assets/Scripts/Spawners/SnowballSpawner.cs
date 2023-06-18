using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour {
    [SerializeField] private GameObject snowBall;
    [SerializeField] private int objectPoolLimit = 5;
    [SerializeField] private float spawnTimeInSeconds = 3f;
    [SerializeField] private float width = 5f, height = 5f, depth = 5f;

    private Queue<GameObject> m_objectPool;
    private bool m_canInstantiate = true;

    private void Start() {
        StartCoroutine(spawning());
        m_objectPool = new Queue<GameObject>();
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to represent the spawn area
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,depth));
    }

    private IEnumerator spawning() {
        while (GameManager.instance.getGameState() != GameState.GameOver) {
            yield return new WaitForSeconds(spawnTimeInSeconds);
            if (GameManager.instance.getGameState() != GameState.Playing) {
                continue;
            }
            float xPos = Random.Range(-width / 2, width / 2);
            Vector3 startPos = new Vector3(xPos, transform.position.y, transform.position.z);
            if (m_canInstantiate) {
                m_objectPool.Enqueue(Instantiate(snowBall, startPos, Quaternion.identity));
                if (m_objectPool.Count > objectPoolLimit) {
                    m_canInstantiate = false;
                }
            }
            else {
                print("Usando objeto viejo " + startPos);
                GameObject tempGo = m_objectPool.Dequeue();
                tempGo.GetComponent<Rigidbody>().velocity = Vector3.zero;
                tempGo.transform.position = startPos;
                tempGo.SetActive(true);
                m_objectPool.Enqueue(tempGo);
            }
        }
    }
}