using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapManager : MonoBehaviour
{
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
