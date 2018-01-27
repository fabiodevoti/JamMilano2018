using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed = 1f;
    public float waitTime = 1f;
    public float range = 0.5f; // under this distance from the target the NPC has arrived
    public Transform[] targets;

    private int state = 0;  //  0 == doesn't know what to do
                            //  1 == is moving
                            //  2 == is waiting

    private float waitTimer = 0f;
    private int selected = 0;
	private Animator anim;
    void Start () 
	{
		anim = GetComponent<Animator> ();
    }
	
	void FixedUpdate () 
	{
        if (state == 0) //doesn't know what to do
        {
            selected = Random.Range(0,targets.Length);

           /* if (selected == targets.Length)
            {
                state = 2;
                waitTimer = waitTime;
            }
			else 
			{
				state = 1;
			}*/
			state = 1;
        }
        else if (state == 1) // is moving
        {

			if (Mathf.Abs (transform.position.x - targets [selected].position.x) <= range) 
			{
				state = 2;
				waitTimer = waitTime;
			} 
			else 
			{
				float direzione = Mathf.Sign (targets [selected].position.x - transform.position.x);

				//gestione animazioni di destra 
				if (direzione > 0) 
				{
					anim.SetBool ("isWalkingR", true);
					anim.SetBool ("isWalkingL", false);
				}

				//gestione animazioni di sinistra
				if (direzione < 0) 
				{
					anim.SetBool ("isWalkingL", true);
					anim.SetBool ("isWalkingR", false);
				}
				transform.Translate(speed * Time.deltaTime * direzione, 0, 0);
			}
                

            
        }
        else if (state == 2) // is waiting
        {
			waitTimer -= Time.deltaTime;

			//gestione animazione di idle
			anim.SetBool ("isWalkingR", false);
			anim.SetBool ("isWalkingL", false);

            if (waitTimer <= 0) state = 0;
        }


	}
}
