using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	[SerializeField] protected RectTransform _slotRect = null;


	private int _row;
	private int _col;
	private Vector2 _center;
	private GameObject _piece;

	public Vector2 Size { get => _slotRect.rect.size; }
	public Vector2 Center { get => _center; }
	public GameObject Piece { get => _piece; }


	public void SetData(int row, int col, Vector2 center)
	{
		_row = row;
		_col = col;
		_center = center;

		_slotRect.anchoredPosition = center;
	}





}
