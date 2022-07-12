using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{
	[SerializeField] protected RectTransform _boardRect = null;
	[SerializeField] protected Transform _slotsParent = null;
	[SerializeField] protected Slot _slotPrefab = null;
	[SerializeField] protected Vector2Int _cells = new Vector2Int(4, 4);
	[SerializeField] private Vector2 _padding = Vector2.zero;

	private Vector2 _origin = Vector2.zero;
	private Vector2 _gap = Vector2.zero;

	private Slot[][] _slots = null;


	private void Awake()
	{
		Vector2 slotSize = _slotPrefab.Size;
		_origin = _boardRect.pivot - (Vector2)_boardRect.rect.size / 2f + slotSize / 2f;

		_gap = _boardRect.rect.size - _padding * 2f - slotSize;
		_gap.x /= (_cells.x - 1);
		_gap.y /= (_cells.y - 1);

		PrepareBoard();
	}

	private void PrepareBoard()
	{
		_slots = new Slot[_cells.y][];

		for (int row = 0; row < _cells.y; ++row)
		{
			_slots[row] = new Slot[_cells.x];
			for (int col = 0; col < _cells.x; ++col)
			{
				_slots[row][col] = NewEmptySlot(row, col);
			}
		}
	}

	private Slot NewEmptySlot(int row, int col)
	{
		float x = _origin.x + _padding.x + _gap.x * col;
		float y = _origin.y + _padding.y + _gap.y * row;

		GameObject slotGO = GameObject.Instantiate(_slotPrefab.gameObject, _slotsParent);
		slotGO.name = $"Slot {row}{col}";

		Slot slot = slotGO.GetComponent<Slot>();
		slot.SetData(row, col, new Vector2(x, y));

		return slot;
	}

}
