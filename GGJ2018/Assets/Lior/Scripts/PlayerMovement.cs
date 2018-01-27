using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	//parameters
	public float speed = 1f;
	public float teleportDistance = 1f;
	public float downJumpForce = 1f;
	public LayerMask layerMask;

	//components
	private Rigidbody2D rb;
	private Animator anim;

	//used for logic
	private bool isUp = false;
	private bool isBase = false;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInChildren<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		HandleMovement ();
		CheckBorders ();
	}

	void Update()
	{
		Teleport ();
	}

	private void HandleMovement()
	{
		float inputH = Input.GetAxis ("Horizontal") * speed;
		 
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			anim.SetBool ("isWalkingR", true);
			anim.SetBool ("isWalkingL", false);
		}

		if (Input.GetAxis ("Horizontal") < 0) 
		{
			anim.SetBool ("isWalkingL", true);
			anim.SetBool ("isWalkingR", false);
		} 
		if (Input.GetAxis ("Horizontal") == 0) 
		{
			anim.SetBool ("isWalkingR", false);
			anim.SetBool ("isWalkingL", false);
		}

		rb.velocity = new Vector2(inputH, rb.velocity.y) * Time.deltaTime;
	}

	private void Teleport()
	{
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && isUp == false) 
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + teleportDistance);
		}
		else if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) && isBase == false) 
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - teleportDistance);
		} 
	}

	private void CheckBorders()
	{
		RaycastHit2D upHit = Physics2D.Raycast (transform.position, Vector2.up, 100f, layerMask);

		if (upHit.collider.gameObject.tag == "Up Border") 
		{
			isUp = true;
		} 
		else 
		{
			isUp = false;
		}
			

		RaycastHit2D baseHit = Physics2D.Raycast (transform.position, Vector2.down, 100f, layerMask);
		//Debug.Log (baseHit.collider.gameObject.tag);

		if (baseHit.collider.gameObject.tag == "Base Border") 
		{
			isBase = true;
		} 
		else 
		{
			isBase = false;
		}
	}
}
