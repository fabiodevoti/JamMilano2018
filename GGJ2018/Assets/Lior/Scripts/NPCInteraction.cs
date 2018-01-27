using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
	public bool isInfected;
	public GameObject player;
	public bool isCured = false;
	public float reactionTime = 1f;
	public float chargeUpTime = 1f;

	public float chargeBar = 0f;

	private bool playerCollision;    // Player in range to show audio & visual cue
	private float timer;


	void Update()
	{
		if (playerCollision == true)
		{
			if (isInfected == true)
			{
				if (timer >= reactionTime)
				{
					player.GetComponent<PlayerMovement> ().isDead = true;
				}
				else if (timer < reactionTime)
				{
					timer += Time.deltaTime;
				}
			}
			else if (Input.GetKey(KeyCode.Space) && isCured == false)
			{
				if (chargeBar >= chargeUpTime)
				{
					//TODO delete charge bar animation
					isCured = true;
					StartCoroutine(ChangeColour(0.5f));
				}
				else
				{
					chargeBar += Time.deltaTime;
				}

			}
		}
		else
		{
			timer = 0f;
			// TODO delete charge bar animation IF IT EXISTS!!!!
			chargeBar = 0f;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Collider2D>().tag == "Player")
		{
			playerCollision = true;

			StartCoroutine(ChangeColour(0.5f));

			/*if(Input.GetKeyDown(KeyCode.Space))
			{
			}*/
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.GetComponent<Collider2D>().tag == "Player")
		{
			playerCollision = false;
		}
	}

	public IEnumerator ChangeColour(float seconds)
	{
		if (isInfected == true)
		{
			gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		else if (isInfected == false && isCured == true)
		{
			Debug.Log(isCured);
			gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
		}

		yield return (new WaitForSeconds(seconds));


		gameObject.GetComponent<SpriteRenderer>().color = Color.white;

	}
}
