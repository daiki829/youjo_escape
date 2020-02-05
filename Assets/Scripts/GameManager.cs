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
	private GameClear gameClear_;

	[SerializeField]
	private Player player_;

	private void Awake()
	{
		minimapManager_.Init(player_);
		goal_.Init(GoalCallback);
		gameClear_.Init();
	}

	private void Start()
	{
		timer_.SetTimer(true);
	}

	private void GoalCallback()
	{
		gameClear_.Clear();
		player_.StopMove();
		timer_.SetTimer(false);
	}
}
