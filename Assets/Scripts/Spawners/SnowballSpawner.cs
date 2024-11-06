using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SnowballSpawner : MonoBehaviour {
    [SerializeField] private float spawnTimeInSeconds = 3f;
    [SerializeField] private float width = 5f, height = 5f, depth = 5f;
    [SerializeField] private Snowball snowBall;
    [SerializeField] private int defatultCapacity = 20;
    [SerializeField] private int maxSize = 30;
    [SerializeField]private int currentObjInPool = 0;
    private bool collectionCheck = false;
    private IObjectPool<Snowball> snowBallPool;
    private void Awake() {
        snowBallPool = new ObjectPool<Snowball>(createSnowball,onGetFromSnowBallPool,onReleaseToSnowBallPool,onDestroySnowBallObject,collectionCheck,defatultCapacity,maxSize);
    }
    private void Start() {
    //    for (int i = 0; i < defatultCapacity; i++) {
    //        Snowball snowball = createSnowball();
    //        if (snowball != null) {
    //            snowBallPool.Release(snowball);
    //        }
    //    }
        StartCoroutine(spawning());
    }

    /// <summary>
    /// funtion to create objects from pool
    /// </summary>
    private Snowball createSnowball() {
        if(currentObjInPool >= maxSize) {
            Debug.LogWarning("the snowBall pool is full");
            return null;
        }
        Snowball snowBallInstance = Instantiate(snowBall);
        //snowBallInstance.SetActive(false);
        snowBallInstance.snowBallPool = snowBallPool;
        return snowBallInstance;
    }

    /// <summary>
    /// funtion to get objects from pool
    /// </summary>
    private void onGetFromSnowBallPool(Snowball snowballObject) {
        snowballObject.gameObject.SetActive(true);
        currentObjInPool++;
    }

    /// <summary>
    /// funtion to deactivate objects
    /// </summary>
    private void onReleaseToSnowBallPool(Snowball snowballObject) {
        Debug.Log("Releasing snowball to pool...");
        snowballObject.gameObject.SetActive(false);
        currentObjInPool--;
    }

    /// <summary>
    /// funtion to destroy objects from pool
    /// </summary>
    private void onDestroySnowBallObject(Snowball snowballObject) {
        Destroy(snowballObject.gameObject);
    }

    private void OnDrawGizmosSelected() {
        // Draw a wire sphere to represent the spawn area
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, depth));
    }

    private IEnumerator spawning() {
        while (GameManager.instance.getGameState() != GameState.GameOver) {
            yield return new WaitForSeconds(spawnTimeInSeconds);
            if (GameManager.instance.getGameState() != GameState.Playing) {
                continue;
            }
            float xPos = Random.Range(-width / 2, width / 2);
            Vector3 startPos = new Vector3(xPos, transform.position.y, transform.position.z);
            Snowball snowball = snowBallPool.Get();
            if(snowball != null) {
                snowBall.transform.position = startPos;
                snowBall.gameObject.SetActive(true);
                snowBall.deactivate();
            }
        }
    }
}