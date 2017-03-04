using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 8f, maxVel = 4f;

    private Rigidbody2D myBody;
    private Animator myAnim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
        Movement();
	}

    void Movement()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0)
        {
            if (vel < maxVel)
            {
                Vector3 temp = transform.localScale;
                temp.x = 4f;
                transform.localScale = temp;

                forceX = speed;
                myAnim.SetBool("walk", true);
            }
        }
        else if(h < 0){
            if (vel < maxVel)
            {
                Vector3 temp = transform.localScale;
                temp.x = -4f;
                transform.localScale = temp;

                forceX = -speed;
                myAnim.SetBool("walk", true);
            }
        }
        else
        {
            myAnim.SetBool("walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }
}
