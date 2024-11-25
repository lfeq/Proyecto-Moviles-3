using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SnowballSpawner : MonoBehaviour 
{
    [SerializeField] private float spawnTimeInSeconds = 5f;
    [SerializeField] private float timeoutDelay = 25f;
    [SerializeField] private Snowball snowBall;
    [SerializeField] private float width = 5f, height = 5f, depth = 5f;
    [SerializeField] private int defatultCapacity = 20;
    [SerializeField] private int maxSize = 30;
    [SerializeField] private int currentObjInPool = 0;
    private bool collectionCheck = false;
    private IObjectPool<Snowball> snowBallPool;
    public Factory factory;
    public ObstaclesInterface obstaclesInterface;

    private void Awake() {
        obstaclesInterface =(ObstaclesInterface) FindObjectOfType<Factory>();
        snowBallPool = new ObjectPool<Snowball>(createSnowball, onGetFromSnowBallPool, onReleaseToSnowBallPool, onDestroySnowBallObject, collectionCheck, defatultCapacity, maxSize);
    }
    private void Start() {
        //obstaclesInterface = (ObstaclesInterface)FindObjectOfType<Factory>();
        //snowBallPool = new ObjectPool<Snowball>(createSnowball, onGetFromSnowBallPool, onReleaseToSnowBallPool, onDestroySnowBallObject, collectionCheck, defatultCapacity, maxSize);
        StartCoroutine(spawning());
    }
    /// <summary>
    /// funtion to create objects from pool
    /// </summary>
    private Snowball createSnowball() {
        if (currentObjInPool >= maxSize) {
            Debug.LogWarning("the snowBall pool is full");
            return null;
        }
        // Snowball snowballInstance = factory.creeateSnowball();
        Snowball snowballInstance =obstaclesInterface.createSnowBall();
        if (snowballInstance == null) {
            Debug.LogError("error al intentar crear una snowball");
        }
        snowballInstance.snowBallPool = snowBallPool;
        snowballInstance.gameObject.SetActive(false);
        return snowballInstance;
    }

    /// <summary>
    /// funtion to get objects from pool
    /// </summary>
    private void onGetFromSnowBallPool(Snowball snowballObject) {
        float xPos = Random.Range(-width / 2, width / 2);
        Vector3 startPos = new Vector3(xPos, transform.position.y, transform.position.z);
        snowballObject.transform.position = startPos;
        snowballObject.gameObject.SetActive(true);
        Rigidbody rigidbody = snowballObject.GetComponent<Rigidbody>();
        if (rigidbody != null) {
            rigidbody.velocity = Vector3.zero; 
            rigidbody.angularVelocity = Vector3.zero; 
        }
        currentObjInPool++;
    }

    /// <summary>
    /// funtion to deactivate objects from pool
    /// </summary>
    private void onReleaseToSnowBallPool(Snowball snowballObject) {
        snowballObject.gameObject.SetActive(false);
        if (currentObjInPool > 0) {
            currentObjInPool--;
        }
    }

    /// <summary>
    /// funtion to destroy objects from pool
    /// </summary>
    private void onDestroySnowBallObject(Snowball snowballObject) {
        Destroy(snowballObject.gameObject);
    }

    private IEnumerator spawning() {
        while (GameManager.instance.getGameState() != GameState.GameOver) {
            yield return new WaitForSeconds(spawnTimeInSeconds);
            if (GameManager.instance.getGameState() != GameState.Playing) {
                continue;
            }
            float xPos = Random.Range(-width / 2, width / 2);
            Vector3 startPos = new Vector3(xPos, transform.position.y, transform.position.z);
            Snowball snowballInstance = snowBallPool.Get();
            if (snowballInstance != null) {
                snowBall.transform.position = startPos;
                snowBall.gameObject.SetActive(true);
                StartCoroutine(deactivateSnowBall(snowballInstance, timeoutDelay));
            } 
        }
    }
    IEnumerator deactivateSnowBall(Snowball snowballInstance,float delay){
        yield return new WaitForSeconds(delay);
        if (snowballInstance != null && snowballInstance.gameObject.activeInHierarchy) {
            snowballInstance.gameObject.SetActive(false);
            snowBallPool.Release(snowballInstance);
        } 
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, depth));
    }
}