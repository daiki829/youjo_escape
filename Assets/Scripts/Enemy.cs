using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Animator animator_;

	[SerializeField]
	private MovePath[] move_path_;

	private float move_speed_;

	private int move_index_ = 0;
	private bool move_forward = true;

    void Start()
    {
		StartCoroutine(AutoMove());
	}

	private void SetAnimation(Vector3 target_pos)
	{
		float distance_x = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(target_pos.x, 0, 0));
		float distance_y = Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, target_pos.y, 0));

		if (distance_x > distance_y)
		{
			if (transform.position.x > target_pos.x)
			{
				animator_.Play("Walk_Left");
			}
			else
			{
				animator_.Play("Walk_Right");
			}

			animator_.speed = 1;
		}
		else if (distance_x < distance_y)
		{

			if (transform.position.y > target_pos.y)
			{
				animator_.Play("Walk_Down");
			}
			else
			{
				animator_.Play("Walk_Up");
			}


			animator_.speed = 1;
		}
		else
		{
			animator_.speed = 0;
		}

		//Debug.Log("X:" + distance_x + "\nY:" + distance_y);
	}

	private IEnumerator AutoMove()
	{
		transform.position = move_path_[0].move_pos.transform.position;
		while (true)
		{
			Vector3 next_pos = move_path_[move_index_].move_pos.transform.position;
			float wait_time = move_path_[move_index_].wait_time;

			move_speed_ = move_path_[move_index_].move_speed;

			SetAnimation(next_pos);

			iTween.MoveTo(gameObject, iTween.Hash("x", next_pos.x, "y", next_pos.y, "speed", move_speed_, "easeType", iTween.EaseType.linear));

			if (Vector3.Distance(transform.position, next_pos) <= 0)
			{
				if (move_forward)
				{
					yield return new WaitForSeconds(wait_time);

					if (++move_index_ >= move_path_.Length)
					{
						move_forward = !move_forward;
						move_index_ = move_path_.Length - 1;
					}
				}
				else
				{
					yield return new WaitForSeconds(wait_time);

					if (--move_index_ <= 0)
					{
						move_forward = !move_forward;

						
					}
				}
			}

			yield return null;
		}
	}

	[System.Serializable]
	public struct MovePath
	{
		[SerializeField] string name;

		public MovePosition move_pos;
		public float wait_time;
		public float move_speed;
	}
}
