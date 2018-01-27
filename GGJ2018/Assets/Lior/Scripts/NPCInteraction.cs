using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour 
{
	public bool isInfected;
	public float reactionTime = 1f;
	public GameObject player;

	private bool playerCollision;
	private float timer;

	void Update()
	{
		if (isInfected == true) 
		{
			if (playerCollision == true) 
			{
				if (timer >= reactionTime) 
				{
					Debug.Log (timer);
					Debug.Log ("YOU LOST!!!!!");
					player.SetActive (false);
				} 
				else if (timer < reactionTime) 
				{
					timer += Time.deltaTime;
				} 
			} 
			else 
			{
				timer = 0f;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Collider2D> ().tag == "Player") 
		{
			playerCollision = true;

			Debug.Log ("works");
			StartCoroutine (ChangeColour(0.5f));

			/*if(Input.GetKeyDown(KeyCode.Space))
			{
			}*/
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.GetComponent<Collider2D> ().tag == "Player") 
		{
			playerCollision = false;
		} 
	}

	public IEnumerator ChangeColour(float seconds)
	{
		if (isInfected == true) 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		} 
		else if (isInfected == false) 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
		}

		yield return (new WaitForSeconds(seconds));

		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			
	}
 }
