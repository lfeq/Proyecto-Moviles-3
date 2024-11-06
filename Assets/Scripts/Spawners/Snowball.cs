using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Snowball : MonoBehaviour
{
    [SerializeField] private float timeoutDelay = 10f;
   public IObjectPool<Snowball> snowBallPool;
    public void deactivate() {
        Debug.LogWarning("se llamo a la funcion deactivateeeeeeeeeeeeeeeeeeeeeee");
        //if (!gameObject.activeInHierarchy) {
        //    return;
        //}
            StartCoroutine(deactivateSnowBall(timeoutDelay));
        Debug.LogWarning("llamando a corrutinaaaaaa");
    }
    IEnumerator deactivateSnowBall(float delay) {
        yield return new WaitForSeconds(delay);
        if(gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
            snowBallPool.Release(this);
            Debug.LogWarning("llego hasta esta corrutina");
        }
    }
}
