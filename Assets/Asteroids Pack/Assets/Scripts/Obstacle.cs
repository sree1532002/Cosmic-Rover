using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * GameController.instance.speed);
        
        if(transform.position.x < -20 || transform.position.x > 20 || transform.position.y > 11 || transform.position.y < -11)
        {
            Destroy(gameObject);
        }
        
    }
}
