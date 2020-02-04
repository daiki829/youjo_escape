using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TileManager : MonoBehaviour
{
	private const int Image_Size_ = 64;
	private const int Max_Map_Size_ = 200;

	[SerializeField]
	private TileCell[] tile_cell_;

	private int[,] map_data_ = new int[Max_Map_Size_, Max_Map_Size_];

	private int map_length_x;
	private int map_length_y;

	private void Start()
	{
		ImportMap();
		MapCreate();
	}

	private void ImportMap()
	{
		string filePath = Application.dataPath + "/StreamingAssets/field.csv";

		string load_data = File.ReadAllText(filePath);
		string[] load_lines = load_data.Split('\n');
		map_length_y = load_lines.Length;

		for (int i = 0; load_lines.Length > i; i++)
		{
			string[] load_cells = load_lines[i].Split(',');
			map_length_x = map_length_x < load_cells.Length ? load_cells.Length : map_length_x;

			for (int j = 0; load_cells.Length > j; j++)
			{
				if (load_cells[j] != "")
				{
					map_data_[i, j] = int.Parse(load_cells[j]);
				}
			}
		}
	}

	private void MapCreate()
	{
		for (int i = 0; map_length_y > i; i++)
		{
			for (int j = 0; map_length_x > j; j++)
			{
				int index = map_data_[j, i];
				int pos_x = i * Image_Size_;
				int pos_y = j * Image_Size_;

				TileCell tile = Instantiate(
					tile_cell_[index],
					new Vector2(pos_x, pos_y),
					new Quaternion());

				tile.transform.parent = this.transform;
			}
		}
	}

	private void MiniMapDraw()
	{
		
	}

	private void CheckCollision()
	{
		
	}
}
