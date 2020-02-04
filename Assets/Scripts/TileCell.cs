using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TileCell : MonoBehaviour
{
	private Action touch_player_callback_;
	public Action touch_player_CallBack_{ set { touch_player_callback_ = value; } }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			touch_player_callback_();
		}

		if (collision.tag == "Enemy")
		{
			
		}
	}
}
