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

    void Start () 
	{
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
				transform.Translate(speed * Time.deltaTime * Mathf.Sign(targets[selected].position.x - transform.position.x), 0, 0);
			}
                

            
        }
        else if (state == 2) // is waiting
        {
			waitTimer -= Time.deltaTime;
            if (waitTimer <= 0) state = 0;
        }


	}
}
