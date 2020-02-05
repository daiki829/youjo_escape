using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapManager : MonoBehaviour
{
	//[SerializeField]
	//private MinimapCell minimapCell_;

	//[SerializeField]
	//private int cell_size_;

	//[SerializeField]
	//private int map_size_;

	//private Player player_;

	//public void Init(Player player)
	//{
	//	player_ = player;
	//}

	//private void Start()
	//{
	//	//CreateMinimapCell();
	//}

	//private void CreateMinimapCell()
	//{
	//	for (int i = 0; map_size_ > i; i++)
	//	{
	//		for (int j = 0; map_size_ > j; j++)
	//		{
	//			float pos_x = -map_size_ / 2 + j + 0.5f;
	//			float pos_y = -map_size_ / 2 + i + 0.5f;

	//			MinimapCell cell = Instantiate(
	//				minimapCell_,
	//				new Vector2(pos_x, pos_y),
	//				minimapCell_.transform.rotation
	//			);

	//			cell.Init(player_, cell_size_);
	//		}
	//	}
	//}

	[SerializeField]
	private Grid grid_;

	[SerializeField]
	private Tilemap tileMap_;

	[SerializeField]
	private Tile minimap_tile_;

	private Player player_;

	public void Init(Player player)
	{
		player_ = player;
	}

	private void Update()
	{
		int pos_x = Mathf.RoundToInt(player_.transform.position.x - 0.5f);
		int pos_y = Mathf.RoundToInt(player_.transform.position.y - 0.5f);
		Vector3Int player_pos = new Vector3Int(pos_x, pos_y, 0);

		tileMap_.SetTile(player_pos, minimap_tile_);
	}
}
