using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
	[SerializeField]
	private Text clear_text_;

	public void Init()
	{
		clear_text_.enabled = false;
	}

	public void Clear()
	{
		clear_text_.enabled = true;
	}
}
