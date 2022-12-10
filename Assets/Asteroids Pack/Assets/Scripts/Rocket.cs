using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float force;

    public static bool isAlive = true;
    private long distance = 0;
    // Start is called before the first frame update
    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            distance++;
            if (distance % 25 == 0)
                IncreaseScore();
        }
    }
    void Update()
    {
        if (Input.touchCount > 0 && isAlive)
        {
            
            // Loop through all the touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                
                Touch touch = Input.GetTouch(i);
                if (touch.position.y > Screen.height / 2)
                {
                    rb2d.AddForce(Vector3.up * force);
                }
                else
                {
                    rb2d.AddForce(Vector3.down * force);
                }
            }
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && isAlive)
        {
            rb2d.AddForce(Vector3.up * force);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (Rocket.GetIsAlive())
        {
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Edge"))
            {
                Debug.Log("Game Over");
                isAlive = false;
                distance = 0;
                GameOver.instance.ShowDialog();
                rb2d.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log(collision.gameObject.tag);
            }
        }
    }
    public static bool GetIsAlive()
    {
        return isAlive;
    }

    private void IncreaseScore()
    {
        Score.SetAmount(Score.GetAmount() + 1);
    }
    public static void SetIsAlive(bool IsAlive)
    {
        Rocket.isAlive = IsAlive;
    }
}