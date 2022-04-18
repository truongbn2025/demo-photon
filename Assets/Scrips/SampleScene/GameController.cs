using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public UIController UIController;
    public NetworkController NetworkController;
    public GameObject UiCanvas;
    
    private LevelController currentLevelController;

    public LevelController CurrentLevelController
    {
        get
        {
            if (!currentLevelController)
            {
                // Debug.LogError($"Level {CurrentLevel} does not have a LevelManager or Level has not been loaded!");
                //Crashlytics.Log($"Level {CurrentLevel} does not have a LevelManager or Level has not been loaded!");
            }
            return currentLevelController;
        }
        private set => currentLevelController = value;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void LoadLevel()
    { 
        
        //SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);
        
        UiCanvas.SetActive(false);
    }
}
