using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset = new Vector3(0,0,-10);
	[SerializeField] private float smoothTime = 0.125f;
	private Vector3 velocity = Vector3.zero;

	void FixedUpdate()
	{
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
