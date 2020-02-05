using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
	private Action goal_callback;
	public Action goal_CallBack { set{ goal_callback = value; } } 

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			goal_callback();
		}
	}

	#region コールバック関数

	#endregion
}
