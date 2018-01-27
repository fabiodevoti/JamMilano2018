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
	public GameObject effettoTeleport;

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
		TeleportInput ();
	}

	private void HandleMovement()
	{
		//input horizontale
		float inputH = Input.GetAxis ("Horizontal") * speed;

		//gestione animazioni di destra 
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			anim.SetBool ("isWalkingR", true);
			anim.SetBool ("isWalkingL", false);
		}

		//gestione animazioni di sinistra
		if (Input.GetAxis ("Horizontal") < 0) 
		{
			anim.SetBool ("isWalkingL", true);
			anim.SetBool ("isWalkingR", false);
		}

		//gestione animazione di idle
		if (Input.GetAxis ("Horizontal") == 0) 
		{
			anim.SetBool ("isWalkingR", false);
			anim.SetBool ("isWalkingL", false);
		}

		//direzione di movimento
		rb.velocity = new Vector2(inputH, rb.velocity.y) * Time.deltaTime;
	}

	private void TeleportInput()
	{
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && isUp == false) 
		{
			StartCoroutine(TeleportUp(0.50f));
		}
		else if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) && isBase == false) 
		{
			StartCoroutine(TeleportDown(0.50f));
		} 
			
	}

	public IEnumerator TeleportUp(float seconds)
	{
		anim.Play ("TeleportPlayer");
		GameObject toDestroy = Instantiate (effettoTeleport, transform);

		yield return (new WaitForSeconds (seconds));

		Destroy (toDestroy);
		transform.position = new Vector2(transform.position.x, transform.position.y + teleportDistance);
	}

	public IEnumerator TeleportDown(float seconds)
	{
		anim.Play ("TeleportPlayer");
		GameObject toDestroy = Instantiate (effettoTeleport, transform);

		yield return (new WaitForSeconds (seconds));

		Destroy (toDestroy);
		transform.position = new Vector2(transform.position.x, transform.position.y - teleportDistance);
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
