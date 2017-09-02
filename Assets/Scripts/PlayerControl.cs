using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControl : MonoBehaviour {

	public enum PlayerNumber
	{
		P1,
		P2
	}

	public PlayerNumber player;

	private string horizontalAxis{
		get{ 
			if (player == PlayerNumber.P1) {
				return "Horizontal";
			} else if (player == PlayerNumber.P2) {
				return "Horizontal_p2";
			} else {
				return "";
			}
		}

	}

	private string verticalAxis{
		get{ 
			if (player == PlayerNumber.P1) {
				return "Vertical";
			} else if (player == PlayerNumber.P2) {
				return "Vertical_p2";
			} else {
				return "";
			}
		}

	}

	private string actionButton{
		get{ 
			if (player == PlayerNumber.P1) {
				return "Fire1";
			} else if (player == PlayerNumber.P2) {
				return "Fire1_p2";
			} else {
				return "";
			}
		}

	}

	private Rigidbody rb;
	public float speed;
	public Transform nose;
	public Transform maxRaycastDistance;
	public Transform firstBrickPathDistance;
	[HideInInspector]
	public int colletiblesCount = 0; 
	private Brick focusedBrick = null;
	private float maxDistanceFromCenter;
	public int shotCost = 1;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
		colletiblesCount = 0;
		maxDistanceFromCenter = new Vector2 (firstBrickPathDistance.position.x, firstBrickPathDistance.position.z).magnitude;
	}

	void Update(){

		Move ();

		Sight ();

		Shoot ();

	}


	void Move ()
	{

		float horizontal = Input.GetAxis (horizontalAxis);
		float vertical = Input.GetAxis (verticalAxis);

		if (horizontal != 0 || vertical != 0) {
		
			Vector3 incrementalPos = new Vector3 (horizontal, 0, vertical) * speed * Time.deltaTime;

			incrementalPos = ClampPos (incrementalPos);

			transform.LookAt (transform.position + incrementalPos);
			transform.Translate (incrementalPos,Space.World);


		}
	}


	Vector3 ClampPos (Vector3 incrementalPos)
	{
		if ((incrementalPos + transform.position).magnitude >= maxDistanceFromCenter) {
			return (incrementalPos + transform.position) * (maxDistanceFromCenter / (incrementalPos + transform.position).magnitude) - transform.position;
		} else{
			return incrementalPos;
		}
	}


	void Sight(){

		RaycastHit[] hitInfo = Physics.RaycastAll(nose.position,transform.forward,(maxRaycastDistance.position - transform.position).magnitude);
	
		bool lookingToBrick = false;

		for (int i = 0; i < hitInfo.Length; i++) {
			if (hitInfo[i].transform.tag == "Brick") {
				Brick brick = hitInfo [i].transform.gameObject.GetComponent<Brick> ();
				if (brick.isDestroyed) {
					if (brick != focusedBrick) {

						if (focusedBrick != null) {
							focusedBrick.Unfocus ();
						}
						focusedBrick = brick;
						focusedBrick.Focus ();

						return;
	
					} else {
						return;
					}
				}
					
			}
				
		}

		if (focusedBrick != null) {
			focusedBrick.Unfocus ();
			focusedBrick = null;
		}

	}

	void Shoot ()
	{
		if (Input.GetButton (actionButton)) {
		
			if (focusedBrick != null) {
			
				if (colletiblesCount >= shotCost) {
				
					focusedBrick.Build ();
					colletiblesCount -= shotCost;
				
				}
			
			}
		
		}
	}

	void KeepAligned ()
	{
		transform.LookAt (transform.position * 1.1f);
	}


	void Collect(GameObject go)
	{
		colletiblesCount += 1;
		Destroy (go);
	}

	void Die(){
	
		Destroy (gameObject);

	}


	public void CollisionWithChild (Collision col)
	{
		return;
	}

	public void TriggerWithChild (Collider col)
	{

		string colTag = col.tag;

		switch (colTag) {
		case "Collectible":
			Collect (col.gameObject);
			break;
		case "Shot":
			Die ();
			break;
		default:
			break;
		}
			
	}
}
