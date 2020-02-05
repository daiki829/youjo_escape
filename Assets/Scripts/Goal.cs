using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
	private Action goal_callback_;

	public void Init(Action goal_callback)
	{
		goal_callback_ = goal_callback;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			goal_callback_();
		}
	}
}
