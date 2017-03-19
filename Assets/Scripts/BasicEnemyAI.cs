using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {

    public Transform playerTarget;
    public float movementSpeed;
    private bool hasLanded;
    private bool hasDirection;
    //private Time lastDeltaTime;
    private int jumpDirection;

	// Use this for initialization
	void Start () {
        playerTarget = GameObject.FindWithTag("Player").transform;
        hasLanded = true;
        hasDirection = true;
        jumpDirection = randomDirectionInt();
    }
	
	// Update is called once per frame
	void Update () {
        // Keeps track of the enemies current position and changes it based on the location of the playerTarget AKA The Player
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, playerTarget.position.y), movementSpeed * Time.deltaTime);

        //Debug.Log("Delta Time == " + Time.deltaTime);
        if(hasLanded) {
            if (playerTarget.position.y > (transform.position.y + 2)) {
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

    private void randomDirection() {
        float randomNumber = Random.Range(-1.5f, 1.0f);
        int direction = (int)randomNumber;
        
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private int randomDirectionInt() {
        float randomNumber = Random.Range(-1.0f, 1.0f);
        int direction = (int)randomNumber;
        while (direction == 0) {
            randomNumber = Random.Range(-1.0f, 1.0f);
            direction = (int)randomNumber;
        }
        
        Debug.Log("Direction is :" + direction);
        return direction;
        //return direction;
        //Debug.Log("Direction is :" + direction);
        //transform.localScale = new Vector3(direction, 1, 1);
    }
}
