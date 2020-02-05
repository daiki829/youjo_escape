using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private MinimapManager minimapManager_;

	[SerializeField]
	private Timer timer_;

	[SerializeField]
	private Goal goal_;

	[SerializeField]
	private Player player_;

	private enum GameState
	{
		STOP,
		PLAYING,
		GOAL
	}
	private GameState game_state_;


	private void Awake()
	{
		minimapManager_.Init(player_);
	}

	private void Update()
	{
		switch(game_state_)
		{
			case GameState.PLAYING :
				Update_Playing(); break;
			case GameState.STOP:
				Update_Stop(); break;
			case GameState.GOAL:
				Update_Goal(); break;
		}
	}

	private void Update_Stop()
	{
		timer_.StopTimer();
	}

	private void Update_Playing()
	{
		timer_.StartTimer();
	}

	private void Update_Goal()
	{
		timer_.StopTimer();
	}
}
