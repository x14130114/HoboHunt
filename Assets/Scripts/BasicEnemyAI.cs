using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {

    public Transform playerTarget;
    public float movementSpeed;

	// Use this for initialization
	void Start () {
        playerTarget = GameObject.FindWithTag("Player").transform; 
	}
	
	// Update is called once per frame
	void Update () {
        // Keeps track of the enemies current position and changes it based on the location of the playerTarget AKA The Player
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, playerTarget.position.y), movementSpeed * Time.deltaTime);

        if(playerTarget.position.x == transform.position.x || playerTarget.position.y != transform.position.y) {
            float randomNumber = Random.Range(-1.0f, 1.0f);
            int direction = (int)randomNumber;
            transform.localScale = new Vector3(direction,1,1);
        } else {

        }

        if(playerTarget.position.x > transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (playerTarget.position.x < transform.position.x) {
            transform.localScale = new Vector3(1, 1, 1); 
        }
	}
}
