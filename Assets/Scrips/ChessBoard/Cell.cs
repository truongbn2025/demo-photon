using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject CellPrefab;
    public Vector3 posOnBoard = Vector3.zero;
    private Vector2 index;
    private bool isOccupied;
    public Board mBoard = null;
    Transform mTransform;

    private void Start()
    {
        isOccupied = false;
    }

    public void createCell(Vector3 thisPosition, Vector2 thisIndex)
    {
        GameObject newCell = Instantiate(CellPrefab, thisPosition, Quaternion.identity, transform);
        index = thisIndex;
    }
    public void Setup(Vector3 position, Board newBoard)
    {
        posOnBoard = position;
        mBoard = newBoard;
        mTransform = GetComponent<Transform>();
    }
}
