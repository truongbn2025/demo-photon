using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField roomName;
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }   

    private void StartGame()
    {
        Debug.Log(roomName.text);
        GameController.Instance.NetworkController.JoinRoom(roomName.text);
        GameController.Instance.LoadLevel();
    }

    public string GetRoomName()
    {
        return roomName.text;
    }

    public string GetPlayerName()
    {
        return playerName.text;
    }

}
