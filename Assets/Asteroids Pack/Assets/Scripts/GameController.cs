using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public ObstacleGenerator obstacleGenerator;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        obstacleGenerator.BeginGenerator();
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
