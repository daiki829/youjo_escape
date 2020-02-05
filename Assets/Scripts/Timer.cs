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
			TimerUpdate();
		}
	}

	public void SetTimer(bool flag)
	{
		on_countup = flag;
	}

	public int GetTime()
	{
		return (int)timer_value;
	}

	private void TimerUpdate()
	{
		timer_value += Time.deltaTime;

		string second = ((int)(timer_value % 60)).ToString("00");
		string minute = ((int)(timer_value / 60)).ToString("00");

		timer_text.text = minute + ":" + second;
	}
}
