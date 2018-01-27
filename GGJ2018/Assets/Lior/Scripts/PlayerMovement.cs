using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 1f;
	public float teleportDistance = 1f;
	public float downJumpForce = 1f;
	public LayerMask layerMask;

	private float gravityForce;
	private Rigidbody2D rb;
	private bool isUp = false;
	private bool isBase = false;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		gravityForce = rb.velocity.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		HandleMovement ();
		CheckBorders ();
	}

	void Update()
	{
		Jump ();
	}

	private void HandleMovement()
	{
		float inputH = Input.GetAxis ("Horizontal") * speed;
		 

		rb.velocity = new Vector2(inputH, rb.velocity.y) * Time.deltaTime;
	}

	private void Jump()
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
