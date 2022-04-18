using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public PlayerSpwaner PlayerSpwaner;
    public Camera mainCamera;

    private void Awake()
    {
        Instance = this;
       
    }

        
}
