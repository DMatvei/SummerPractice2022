using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCamera : MonoBehaviour
{
    public Transform player;

    public float dumping = 1.5f;
    public Vector2 offset = Vector2.zero;



	
	public float leftLimit;
	public float rightLimit;
	public float bottomLimit;
	public float topLimit;

	private void Start()
	{
        
	}

	private void Update()
	{
		Vector3 target = new Vector3(player.position.x, player.position.y, -10f);

		Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
		transform.position = currentPosition;


		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
			Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
			-10f);

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red; 
		Gizmos.DrawLine(new Vector3(leftLimit, topLimit, 0), new Vector3(rightLimit, topLimit, 0));
		Gizmos.DrawLine(new Vector3(leftLimit, bottomLimit, 0), new Vector3(rightLimit, bottomLimit, 0));
		Gizmos.DrawLine(new Vector3(leftLimit, bottomLimit, 0), new Vector3(leftLimit, topLimit, 0));
		Gizmos.DrawLine(new Vector3(rightLimit, bottomLimit, 0), new Vector3(rightLimit, topLimit, 0));
	}
}

