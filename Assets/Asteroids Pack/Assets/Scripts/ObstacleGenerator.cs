using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    
    public float delay;

    public float maxYLimit;
    public float minYLimit;

    Coroutine coroutine;

    public void BeginGenerator(){
        coroutine = StartCoroutine(Begin());
    }

    public void StopGeneration(){
        if(coroutine != null){
            StopCoroutine(coroutine);
        }
    }
    IEnumerator Begin(){
        while(true){
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(transform.position.x, Random.Range(minYLimit, maxYLimit)), transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }   
}
