using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float force;

    public bool isAlive = true;
    // Start is called before the first frame update
    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isAlive){
            rb2d.AddForce(Vector3.up * force);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("Game Over");
            isAlive = false;
        }else{
            Debug.Log(collision.gameObject.tag);
        }
    }
}
