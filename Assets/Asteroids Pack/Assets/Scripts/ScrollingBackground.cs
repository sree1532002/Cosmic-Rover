using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    Material material;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Rocket.GetIsAlive())
            material.SetTextureOffset("_MainTex", material.GetTextureOffset("_MainTex") + (Vector2.left * Time.deltaTime * GameController.speed * speed));
    }
}
