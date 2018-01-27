using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class CameraFollow : MonoBehaviour
{
    public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate ()
	{
		Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
	}
}*/

public class CameraFollow : MonoBehaviour
    {

        public float interpVelocity;
        public float minDistance;
        public float followDistance;
        public GameObject target;
        public Vector3 offset;
        Vector3 targetPos;
        // Use this for initialization
        void Start()
        {
            targetPos = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (target)
            {
                Vector3 posNoZ = transform.position;
                posNoZ.z = target.transform.position.z;

                Vector3 targetDirection = (target.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 5f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

            }
        }
    }