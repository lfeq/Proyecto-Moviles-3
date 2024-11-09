using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Snowball : MonoBehaviour
{
    //[SerializeField] private float timeoutDelay = 10f;
   public IObjectPool<Snowball> snowBallPool;
    //public void deactivate() {
    //    Debug.LogWarning("se llamo a la funcion deactivateeeeeeeeeeeeeeeeeeeeeee");
    //    //if (!gameObject.activeInHierarchy) {
    //    //    return;
    //    //}
    //        StartCoroutine(deactivateSnowBall(timeoutDelay));
    //    Debug.LogWarning("llamando a corrutinaaaaaa");
    //}
    //IEnumerator deactivateSnowBall(float delay) {
    //    Debug.LogWarning("llego antes del if de la corrutina");
    //    yield return new WaitForSeconds(delay);
    //    if (gameObject.activeInHierarchy) {
    //        gameObject.SetActive(false);
    //        snowBallPool.Release(this);
    //        Debug.LogWarning("llego hasta esta corrutina");
    //    }
    //}

   // public IObjectPool<Snowball> snowBallPool;

    //public override void showObstacle() {
    //    Debug.Log("Mostrando Snowball");
    //}

    public void DeactivateWithDelay(float delay) {
        //StartCoroutine(DeactivateSnowBall(delay));
    }

    private IEnumerator DeactivateSnowBall(float delay) {
        yield return new WaitForSeconds(delay);

        //if (gameObject.activeInHierarchy) {
        //    gameObject.SetActive(false);
        //    snowBallPool.Release(this);
        //    Debug.Log("Snowball desactivado y devuelto al pool.");
        //}
    }
}
