using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;
    public Board Board;
    void Start()
    {
        Board.createBoard(8, 8);
    }


    void Update()
    {
        
    }
}
