using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
    //public static NetworkController instance;
    [SerializeField] string roomName="";
    

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("created room " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("created room fail");
        CreateRoom(roomName + "(1)");
    }

    public void JoinRoom(string thisRoomName)
    {
        roomName = thisRoomName;
        
        PhotonNetwork.JoinRoom(roomName);


    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("join room fail");
        CreateRoom(roomName);
        JoinRoom(roomName);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined" + PhotonNetwork.CurrentRoom);
        PhotonNetwork.LoadLevel("game-scene");
    }
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

}
