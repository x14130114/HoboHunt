using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//creating the bullet
public class Bullet : MonoBehaviour {

    public float bulletSpeed; //how fast is the bullet moving?

    private Rigidbody2D theRB;
	
	void Start () {
        theRB = GetComponent<Rigidbody2D>(); //attaching this script to the component rigidbody = physics
       
    }
	
	void Update () {
        theRB.velocity = new Vector2(bulletSpeed * transform.localScale.x, 0); //flipping the bullet when shooting left or right	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
            Destroy(gameObject); //
        
    }

    

}
