using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public Vector3 centre = Vector3.zero;
	public float force = 1.0f;
	Rigidbody arrow;

	void Start()
	{
		arrow = GetComponent<Rigidbody>();
		arrow.centerOfMass = centre;
		arrow.isKinematic = false;
		arrow.collisionDetectionMode = CollisionDetectionMode.Continuous;
		arrow.AddForce(arrow.transform.forward * force, ForceMode.Impulse);	
	}

	void FixedUpdate()
	{
		if (!arrow.isKinematic)
		{
			arrow.MoveRotation(Quaternion.LookRotation(arrow.velocity));
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.LogFormat($"Mass = {arrow.mass}, Hit Velocity {collision.relativeVelocity.magnitude}");
		arrow.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		arrow.isKinematic = true;
		arrow.detectCollisions = false;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.TransformPoint(centre), 0.1f);
	}
}
