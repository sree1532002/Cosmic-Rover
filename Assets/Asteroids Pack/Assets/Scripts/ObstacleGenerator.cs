using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject coins;
    // Start is called before the first frame update
    
    public float delay;

    private readonly float maxYLimit = 10;
    private readonly float minYLimit = -10;
    private float range;

    Coroutine coroutine;

    public void BeginGenerator(){
        range = (float) (maxYLimit - minYLimit) / 4;
        coroutine = StartCoroutine(Begin());
    }

    public void StopGeneration(){
        if(coroutine != null){
            StopCoroutine(coroutine);
        }
    }
    IEnumerator Begin(){
        while(true){
            float pos1 = Random.Range(minYLimit, minYLimit + range - 0.5f);
            float pos2 = Random.Range(minYLimit + range + 0.5f, minYLimit + range + range - 0.5f);
            float pos3 = Random.Range(minYLimit + range + range + 0.5f, maxYLimit - range -0.5f);
            float pos4 = Random.Range(maxYLimit - range + 0.5f, maxYLimit);
            List<float> positions = new() { pos1, pos2, pos3, pos4 };
            List<string> values = new() { "asteroid", "coin" , "empty"};
            List<int> xPosition = new() { -1, 0, 1 };

            for (int i=0; i<4; i++)
            {
                int randomLaneIndex = Random.Range(0, positions.Count);
                int randomTypeIndex = Random.Range(0, values.Count);
                int randomXPostitionIndex = Random.Range(0, xPosition.Count);

                SpawnObject(values[randomTypeIndex], positions[randomLaneIndex], xPosition[randomXPostitionIndex]);

                positions.RemoveAt(randomLaneIndex);
                
            }
            
            yield return new WaitForSeconds(delay);
        }
    }

    public void SpawnObject(string type, float pos, int mult)
    {
        float xPos = Random.Range(-5, 5);
        if (type.Equals("asteroid"))
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(transform.position.x + mult*xPos, pos), transform.rotation);
        } else if (type.Equals("coin"))
        {
            Instantiate(coins, new Vector3(transform.position.x + mult * xPos, pos), transform.rotation);
        }
        
    }
    
}
