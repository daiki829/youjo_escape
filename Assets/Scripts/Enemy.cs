using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private MovePath[] move_path_;

	[SerializeField]
	private float move_speed_;

	private int move_index_ = 0;
	private bool move_forward = true;

	public enum MoveSwitch
	{
		Move1,
		Move2
	}
	[SerializeField]
	private MoveSwitch moveswitch;
	

    void Start()
    {
		StartCoroutine(AutoMove());
	}

	private IEnumerator AutoMove()
	{
		while (true)
		{
			Vector3 next_pos = move_path_[move_index_].transform.position;

			iTween.MoveTo(gameObject, iTween.Hash("x", next_pos.x, "y", next_pos.y, "speed", move_speed_, "easeType", iTween.EaseType.linear));

			if (Vector3.Distance(transform.position, next_pos) <= 0)
			{
				if (move_forward)
				{
					move_index_++;

					yield return new WaitForSeconds(1);

					if (move_index_ >= move_path_.Length)
					{
						move_forward = !move_forward;
						move_index_ = move_path_.Length - 1;
					}
				}
				else
				{
					move_index_--;
					yield return new WaitForSeconds(1);

					if (move_index_ <= 0)
					{
						move_forward = !move_forward;

						
					}
				}
			}

			yield return null;
		}
	}
}
