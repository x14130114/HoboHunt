using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int speed = 8;
    private Rigidbody2D myBody;
    private Animator myAnim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
		
	void FixedUpdate () {
        Movement();
	}

    void Movement()
    {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
			myAnim.SetBool ("walk", true);
			Vector3 temp = transform.localScale;
			temp.x = -4f;
			transform.localScale = temp;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
			myAnim.SetBool ("walk", true);
			Vector3 temp = transform.localScale;
			temp.x = 4f;
			transform.localScale = temp;
		} else {
			myAnim.SetBool ("walk", false);
		}
    }
}