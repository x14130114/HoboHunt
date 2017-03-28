using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public Transform playerTarget;
    public int hitPoints = 1;
    public float movementSpeed = 1f;


    // Use this for initialization
    public void Start()
    {
        playerTarget = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Update()
    {
        // Keeps track of the enemies current position and changes it based on the location of the playerTarget AKA The Player
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, playerTarget.position.y), movementSpeed * Time.deltaTime);
        // Compares the location of the enemy to the postion of the player and sets the movement in that direction.
        if (playerTarget.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (playerTarget.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
