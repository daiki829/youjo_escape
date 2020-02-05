using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCell : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer spriteRenderer_;

	private Player player_;
	private int cell_size_;


	public void Init(Player player, int cell_size)
	{
		player_ = player;
		cell_size_ = cell_size;
	}

	private void Update()
	{
		CheckHit();
	}

	private void ActiveCell()
	{
		spriteRenderer_.enabled = true;
	}

	private void CheckHit()
	{
		float distance = Vector2.Distance(this.transform.position, player_.transform.position);

		Debug.Log(distance);
	}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (collision.tag == "Player")
	//	{
	//		ActiveCell();
	//	}
	//}
}
