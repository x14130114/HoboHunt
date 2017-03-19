using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboCop : MonoBehaviour {

    //variables
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;

    private Rigidbody2D theRB;


    //referencing the groundCheck - is our player on the ground? Important for jumping functionality
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask thisIsGround;
    public bool isGrounded;


    //referencing the animator (animations won't do transitions without this)
    private Animator anim;

   
    public GameObject bullet; //referencing the "soap" bullet HoboCop is shooting
    public Transform ShootPoint; //referencing where the bullet is coming out of

    // Using the RigidBody object (rigidbody = physics)
	void Start () {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //instantiate the animator object for animations to work
	}
	
	// Creating movement for Left and Right
	void Update () {

        //creating the isGrounded true
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, thisIsGround);

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }

        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else {
            theRB.velocity = new Vector2(0, theRB.velocity.y); //important else as it prevents character from floating left or right when you press the button
        }

        //Creating jumping
        if (Input.GetKeyDown(jump) && isGrounded) //this if holds the isGrounded statement as well
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(shoot)) //when we press the button the character shoots the bullets
        {
            GameObject bulletClone = (GameObject)Instantiate(bullet, ShootPoint.position, ShootPoint.rotation); 
            bulletClone.transform.localScale = transform.localScale; //bulletClone is fixing the bullet when you turn to shoot on the left side (bullet localScale is equal to the player scale)
            anim.SetTrigger("Shoot"); //referencing the Shoot parameter from the animation parameters e.g. grounded, speed, shot etc.
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //flipping the player when we move to the left
        }
        else if (theRB.velocity.x > 0) //flipping the player back to the right (the ONES are actually XYZ) (again negative/positive value, makes sense really)
        {
           transform.localScale = new Vector3(1, 1, 1);
        }

        //telling the animator what to do (at the end of the loop)
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x)); //Mathf.Abs help with moving left (without it the animation when walking left wont work (because going left represents/or is using NEGATIVE value)) 
        anim.SetBool("Grounded", isGrounded);
	}

        void OnTriggerEnter2D(Collider2D other) //any other collider will cause a Trigger. E.G. HoboCop touches the enemy and dies? 
        {
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
        }
}
