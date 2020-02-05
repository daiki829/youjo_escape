using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField]
	private Text timer_text;

	private float timer_value;
	private bool on_countup = false;

	private void Update()
	{
		if (on_countup)
		{
			timer_value += Time.deltaTime;
			timer_text.text = timer_value.ToString();
		}
	}

	public void StartTimer()
	{
		on_countup = true;
	}

	public void StopTimer()
	{
		on_countup = false;
	}
}
