using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;			

	public bool hasRightTile = false;
	public bool hasLeftTile = false;

	public bool reverseScale = false;	

	private float spriteWidth = 0f;		
	private Camera cam;
	private Transform myTransform;

	void Awake () {
		cam = Camera.main;
		myTransform = transform;
	}

	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	void Update () {
		if (hasLeftTile == false || hasRightTile == false) {
			float camHorizontalExtend = cam.orthographicSize * Screen.width/Screen.height;

			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth/2) + camHorizontalExtend;

			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasRightTile == false)
			{
				MakeNewBuddy (1);
                hasRightTile = true;
			}
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasLeftTile == false)
			{
				MakeNewBuddy (-1);
                hasLeftTile = true;
			}
		}
	}

	void MakeNewBuddy (int rightOrLeft) {
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x*-1, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		newBuddy.parent = myTransform.parent;
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling>().hasLeftTile = true;
		}
		else {
			newBuddy.GetComponent<Tiling>().hasRightTile = true;
		}
	}
}
