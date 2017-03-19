using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {

    public Transform playerTarget;
    public float movementSpeed;
    public float jumpThreshold;
    private bool hasLanded;
    //private Time lastDeltaTime;
    private int jumpDirection;

	// Use this for initialization
	void Start () {
        playerTarget = GameObject.FindWithTag("Player").transform;
        hasLanded = true;
        jumpDirection = randomDirectionInt();
    }
	
	// Update is called once per frame
	void Update () {
        // Keeps track of the enemies current position and changes it based on the location of the playerTarget AKA The Player
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, playerTarget.position.y), movementSpeed * Time.deltaTime);

        //Debug.Log("Delta Time == " + Time.deltaTime);
        // Check if Player has landed
        if(hasLanded) {
            // Check if players Y axis is Greater than the enemies Y axis by jumpThreshold units
            Debug.Log("playerTarget.position = " + playerTarget.position.y);
            Debug.Log("transform.position = " + transform.position.y);
            Debug.Log("transform.position ++ = " + (playerTarget.position.y + jumpThreshold));
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
}
