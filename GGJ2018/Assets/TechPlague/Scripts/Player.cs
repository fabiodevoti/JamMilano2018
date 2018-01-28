using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	//parameters
	public float speed = 1f;
	public float teleportDistance = 1f;
	public float downJumpForce = 1f;
	public LayerMask layerMask;
	public GameObject effettoTeleport;

	public AudioClip teleport;
	public AudioClip death;

	[HideInInspector]
	public bool isDead = false;
    [HideInInspector]
    public bool canMove = false;

    //components
    private Rigidbody2D rb;
	private Animator anim;
	private AudioSource audioSource;

	private bool isWatchingR = false;

	//used for logic
	private bool isUp = false;
	private bool isBase = false;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInChildren<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//player dies
		if (isDead == true) 
		{
			if(audioSource.isPlaying == false)
			audioSource.PlayOneShot (death);

			anim.SetBool("isDead", true);

            canMove = false;

		}
		if (canMove == true) HandleMovement ();
		CheckBorders ();
	}

	void Update()
	{
		
		if (canMove == true) TeleportInput ();


	}

	public void HandleMovement()
	{
		//input horizontale
		float inputH = Input.GetAxis ("Horizontal") * speed;

		//gestione animazioni di destra 
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			isWatchingR = true;

			anim.SetBool ("isWalkingR", true);
			anim.SetBool ("isWalkingL", false);
		}

		//gestione animazioni di sinistra
		if (Input.GetAxis ("Horizontal") < 0) 
		{
			isWatchingR = false;

			anim.SetBool ("isWalkingL", true);
			anim.SetBool ("isWalkingR", false);
		}

		//gestione animazione di idle
		if (Input.GetAxis ("Horizontal") == 0) 
		{
			anim.SetBool ("isWalkingR", false);
			anim.SetBool ("isWalkingL", false);
		}

		/*if (Input.GetAxis ("Horizontal") == 0) 
		{
			FindObjectOfType<AudioManager>().Play ("Steps");
		}*/

		//direzione di movimento
		rb.velocity = new Vector2(inputH, rb.velocity.y) * Time.deltaTime;
	}

	private void TeleportInput()
	{
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && isUp == false) 
		{
			StartCoroutine(TeleportUp(0.60f));
		}
		else if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) && isBase == false) 
		{
			StartCoroutine(TeleportDown(0.60f));
		} 
			
	}

	public IEnumerator TeleportUp(float seconds)
	{
		audioSource.PlayOneShot(teleport);
		if (isWatchingR == true) 
		{
			
			anim.Play ("TeleportPlayerR");
		} 
		else 
		{
			anim.Play ("TeleportPlayerL");
		}

		GameObject toDestroy = Instantiate (effettoTeleport, transform);

		yield return (new WaitForSeconds (seconds));

		Destroy (toDestroy);
		transform.position = new Vector2(transform.position.x, transform.position.y + teleportDistance);
	}

	public IEnumerator TeleportDown(float seconds)
	{
		audioSource.PlayOneShot(teleport);
		if (isWatchingR == true) 
		{
			
			anim.Play ("TeleportPlayerR");
		} 
		else 
		{
			anim.Play ("TeleportPlayerL");
		}

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
