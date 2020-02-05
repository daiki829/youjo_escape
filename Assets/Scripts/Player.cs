using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rigidbody_;

	[SerializeField]
	private float move_speed;

	private void Update()
	{
		PlayerMove();
	}

	private void PlayerMove()
	{
		float input_x = Input.GetAxis("Horizontal");
		float input_y = Input.GetAxis("Vertical");
		Vector2 move_pos = new Vector2(input_x, input_y) * move_speed * Time.deltaTime;

		transform.Translate(move_pos);
	}
}
