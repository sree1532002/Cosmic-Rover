using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //private AudioSource audioSource;
    private bool taken;

    void Start()
    {
        //audioSource = this.GetComponent<AudioSource>();
        taken = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * GameController.instance.speed);
        if (transform.position.x < -20 || transform.position.x>20 || transform.position.y>11 || transform.position.y<-11)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        
        // Checks if coin has been taken. (Because player can re-enter coin while coin destroy animation is playing)
        if (!taken)
        {
            if (col.CompareTag("Rocket"))
            {
                // Increases player wallet amount.
                Wallet.SetAmount(Wallet.GetAmount() + 1);
                // Play coin destroy animation.
                Destroy(gameObject);
                // Play coin collect sound.
                //audioSource.Play();
                // Sets coin as taken.
                taken = true;
            }

        }
    }
}
