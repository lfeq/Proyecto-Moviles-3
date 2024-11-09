using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Snowball : Obstacle
{
    public IObjectPool<Snowball> snowBallPool;

    public override void showObstacle() {
        Debug.Log("sostrando snowball");
    }

    public void deactivateSnowBall(float delay) {
        StartCoroutine(deactivateSnowBallCoroutine(delay));
    }

    private IEnumerator deactivateSnowBallCoroutine(float delay) {
        yield return new WaitForSeconds(delay);
        if (gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
            snowBallPool.Release(this);
            Debug.Log("regreso al pool");
        }
    }
}
