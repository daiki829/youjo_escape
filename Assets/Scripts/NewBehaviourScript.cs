using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField]
	private BoundsInt area;

	private void Start()
	{
		Tilemap tilemap = GetComponent<Tilemap>();
		TileBase[] tileArray = tilemap.GetTilesBlock(area);
		for (int index = 0; index < tileArray.Length; index++)
		{
			print(tileArray[index]);
		}
	}
}
