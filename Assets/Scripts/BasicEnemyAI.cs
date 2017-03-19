using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : EnemyBase {

    public float jumpThreshold;
    private bool hasLanded;
    private int jumpDirection;
    public int scoreValue;
    private HoboCop hoboCop;

    void Start() {
        base.Start();
        hasLanded = true;
        jumpDirection = randomDirectionInt();
        GameObject hoboCopObject = GameObject.FindWithTag("Player");
        if (hoboCopObject != null)
        {
            hoboCop = hoboCopObject.GetComponent<HoboCop>();
        }
        if (hoboCop == null)
        {
            Debug.Log("Cannot find");
        }
    }

    void Update () {
        base.Update();

        // Check if Player has landed
        if(hasLanded) {
            // Check if players Y axis is Greater than the enemies Y axis by jumpThreshold units
            if ((playerTarget.position.y + jumpThreshold) > transform.position.y && playerTarget.position.x == transform.position.x) {
                hasLanded = false;
                transform.localScale = new Vector3(jumpDirection, 1, 1);
            } else {
                hasLanded = true;
                if (playerTarget.position.x > transform.position.x) {
                    transform.localScale = new Vector3(-1, 1, 1);
                } else if (playerTarget.position.x < transform.position.x) {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        } else {
            transform.localScale = new Vector3(jumpDirection, 1, 1);
        }
    }

    // Method to create an integer of either 1 or -1
    private int randomDirectionInt() {
        float randomNumber = Random.Range(-1.0f, 1.0f);
        int direction = (int)randomNumber;

        while (direction == 0) {
            randomNumber = Random.Range(-1.0f, 1.0f);
            direction = (int)randomNumber;
        }
        
        Debug.Log("Direction is :" + direction);
        return direction;
    }

    void OnTriggerEnter2D(Collider2D other) //enemy gets destroyed by on-trigger colliders and goes out of the game (saving resources) 
    {

        if (other.tag == "Bullet")
        {
            hoboCop.AddScore(scoreValue);
            Destroy(gameObject);
        }

    }
}
