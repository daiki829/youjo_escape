using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rigidbody_;

	[SerializeField]
	private float move_speed;

	[SerializeField]
	private SpriteRenderer spriteRenderer_;

	[SerializeField]
	private Animator animator_;

	private float input_x;
	private float input_y;

	private bool on_move_ = true;

	private void Update()
	{
		if (on_move_)
		{
			PlayerMove();
		}
		PlayerAnimation();
	}

	public void StopMove()
	{
		on_move_ = false;
		input_x = 0;
		input_y = 0;
	}

	private void PlayerMove()
	{
		input_x = Input.GetAxis("Horizontal");
		input_y = input_x == 0 ? Input.GetAxis("Vertical") : 0;

		Vector2 move_pos = new Vector2(input_x, input_y) * move_speed * Time.deltaTime;

		transform.Translate(move_pos);
	}

	private void PlayerAnimation()
	{
		if (input_x > 0)
		{
			animator_.Play("Walk_Right");
			animator_.speed = 1;
		}
		else if (input_x < 0)
		{
			animator_.Play("Walk_Left");
			animator_.speed = 1;
		}
		else if (input_y > 0)
		{
			animator_.Play("Walk_Up");
			animator_.speed = 1;
		}
		else if (input_y < 0)
		{
			animator_.Play("Walk_Down");
			animator_.speed = 1;
		}
		else
		{
			animator_.speed = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			StartCoroutine(WaitMove());
		}
	}

	private IEnumerator WaitMove()
	{
		if (on_move_ == false) yield break;

		const float Wait_Time = 2;

		on_move_ = false;
		input_x = 0;
		input_y = 0;

		yield return new WaitForSeconds(Wait_Time);

		on_move_ = true;
	}
}
