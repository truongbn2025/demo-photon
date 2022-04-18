using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    const int LENGTH_X = 8;
    const int LENGTH_Y = 8;
    public GameObject CellPrefab;
    public Cell cell;
    public Cell[,] listCell = new Cell[LENGTH_X, LENGTH_Y];
    private void Start()
    {
        //createBoard(8, 8);
    }
    public void createBoard(int x, int y)
    {
        for(int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                
                Vector3 cellPos = new Vector3(i, 0, j);
                Vector2 cellIndex = new Vector2(i, j);
                GameObject newCell = Instantiate(CellPrefab, cellPos, Quaternion.identity, transform);
                //Transform cellTransform = newCell.GetComponent<Transform>();
                listCell[i, j] = newCell.GetComponent<Cell>();
                listCell[i, j].Setup(cellPos, this);
                //listCell[i, j].createCell(cellPos, cellIndex);
                //listCell[i, j] = newCell;
            }
        }
    }
}
