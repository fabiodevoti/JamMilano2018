using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
	public bool isInfected;
	public GameObject player;
    public GameObject visibleBar;
	public bool isCured = false;
	public float reactionTime = 1f;
	public float chargeUpTime = 1f;
	public float chargeBar = 0f;

	public AudioClip bar;
	public AudioClip infected;
	public AudioClip cured;

	private bool playerCollision;    // Player in range to show audio & visual cue
	private float timer;
	private AudioSource audioSource;
    private GameObject toDestroy;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
	}
    /*      // VERSIONE UTILIZZABILE MA PESANTE PER IL LAG; HO CAMBIATO ANCHE OnTriggerExit2D
     *      // PROBABILMENTE DA CANCELLARE MA MAI PUSHATO IN QUESTA VERSIONE
	void Update()
	{
		if (playerCollision == true)
		{
			if (isInfected == true)
			{
				if (timer >= reactionTime)
				{
					player.GetComponent<Player> ().isDead = true;
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
					
					audioSource.Stop();

                   
                    visibleBar.SetActive(false);
                    Debug.Log("reset");
                   

                    isCured = true;
                    FindObjectOfType<GameManag>().cured ++;
					StartCoroutine(ChangeColour(0.5f));
                    chargeBar = 0f;

                }
                else
				{
                    //if (visibleBar.activeInHierarchy == false)
                        visibleBar.SetActive(true);
                    Debug.Log(chargeBar);

					//audioSource.clip = bar;
					if(audioSource.isPlaying == false)
						audioSource.PlayOneShot(bar);
					chargeBar += Time.deltaTime;
				}

			}
		}
		else
		{
			timer = 0f;

           
            visibleBar.SetActive(false);
            Debug.Log("reset");

            chargeBar = 0f;
		}
	}*/

    void FixedUpdate()
    {
        if (playerCollision == true)
        {
            if (isInfected == true)
            {
                if (timer >= reactionTime)
                {
                    player.GetComponent<Player>().isDead = true;
                }
                else if (timer < reactionTime)
                {
                    timer += Time.deltaTime;
                }
            }
            else if (isCured == false)
            {
                if (Input.GetKey(KeyCode.Space) == true)
                {
                    if (chargeBar >= chargeUpTime)
                        {

                        audioSource.Stop();
                        
                        visibleBar.SetActive(false);
                        Debug.Log("reset");

                        isCured = true;
                        FindObjectOfType<GameManag>().cured++;
                        StartCoroutine(ChangeColour(0.5f));
                        chargeBar = 0f;

                    }
                    else
                        {
                        //if (visibleBar.activeInHierarchy == false)
                        visibleBar.SetActive(true);
                        Debug.Log(chargeBar);

                        //audioSource.clip = bar;
                        if (audioSource.isPlaying == false)
                            audioSource.PlayOneShot(bar);
                        chargeBar += Time.deltaTime;
                    }
                }
                else
                {
                    audioSource.Stop();

                    visibleBar.SetActive(false);
                    Debug.Log("reset");
                    chargeBar = 0f;
                }
                

            }
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

            //TODO: ma se sta collidendo con due tipi smette il caricamento anche se solo uno si allontana!!!!
			playerCollision = false;

            if (isInfected == true)
            {
                timer = 0f;
            }
            else if(isCured == false)
            {
                visibleBar.SetActive(false);
                Debug.Log("reset");
                chargeBar = 0f;
            }
        }
	}

	public IEnumerator ChangeColour(float seconds)
	{
		if (isInfected == true)
		{
			if(audioSource.isPlaying == false)
			audioSource.PlayOneShot (infected);
			
			gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		else if (isInfected == false && isCured == true)
		{
			audioSource.PlayOneShot (cured);
			gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
		}

		yield return (new WaitForSeconds(seconds));
		
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;

	}
}
