using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BG : MonoBehaviour{
    // List to store the prefab GameObjects for the backgrounds
    public GameObject[] backgrounds;

    // Offset to determine how far apart each background should be
    public float offset = 500f;
    public int count = 2;
    void Start()
    {
        // Iterate through the list of prefabs and instantiate them in the scene
        for (int i = 0; i <= count; i++)
        {
            GameObject prefab = Instantiate(backgrounds[i]);
            prefab.transform.position = new Vector2(i * offset + 200, 0);
        }

        // Start a coroutine to continuously loop the backgrounds
        StartCoroutine(BackgroundLoop());
    }

    IEnumerator BackgroundLoop()
    {
        while (true)
        {
            // Find the first and last backgrounds in the scene
            GameObject firstBackground = GameObject.Find("Background(Clone)");
            GameObject lastBackground = GameObject.Find("Background(Clone)(" + (count - 1) + ")");

            // Destroy the first background and instantiate a new one at the end of the scene
            Destroy(firstBackground);
            GameObject prefab = Instantiate(backgrounds[0]);
            prefab.transform.position = new Vector2(lastBackground.transform.position.x + offset, 0);

            yield return new WaitForSeconds(20f);
        }
    }
}