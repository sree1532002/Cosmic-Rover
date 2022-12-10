using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BG : MonoBehaviour{
    // List to store the prefab GameObjects for the backgrounds
    public GameObject[] backgrounds;
    void Start()
    {
        // Iterate through the list of prefabs and instantiate them in the scene
        foreach (GameObject prefab in backgrounds)
        {
            prefab.transform.position = new Vector2(0, 0);
        }
        // Start a coroutine to continuously loop the backgrounds
        StartCoroutine(BackgroundLoop());
    }

    IEnumerator BackgroundLoop()
    {
        while (true && Rocket.GetIsAlive())
        {
            // Find the first and last backgrounds in the scene
            GameObject firstBackground = null;
            GameObject lastBackground = null;
            GameObject prefab;
            if(GameObject.Find("BG1(Clone)")){
                firstBackground = GameObject.Find("BG1(Clone)");
                Destroy(firstBackground);
                prefab = Instantiate(backgrounds[1]);
                prefab.transform.position = new Vector2(0, 0);
            }
            else if(GameObject.Find("BG2(Clone)")){
                lastBackground = GameObject.Find("BG2(Clone)");
                Destroy(lastBackground);
                prefab = Instantiate(backgrounds[2]);
                prefab.transform.position = new Vector2(0, 0);
            }
            else{
                lastBackground = GameObject.Find("BG3(Clone)");
                Destroy(lastBackground);
                prefab = Instantiate(backgrounds[0]);
                prefab.transform.position = new Vector2(0, 0);
            }               
            yield return new WaitForSeconds(10f);
        }
    }
}