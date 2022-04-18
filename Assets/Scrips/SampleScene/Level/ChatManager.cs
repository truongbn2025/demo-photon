using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using TMPro;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    ChatClient chatClient;
    private string userId;
    public TMP_InputField inputField;
    public Button sendButton;
    public TMP_Text chat;
    #region implemented

    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    public void OnChatStateChange(ChatState state)
    {
       
    }

    public void OnConnected()
    {
        Debug.Log("Connected chat room: "+ GameController.Instance.UIController.GetRoomName());
        chatClient.Subscribe(GameController.Instance.UIController.GetRoomName());
    }

    public void OnDisconnected()
    {
   
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        int msgCount = messages.Length;
        for (int i = 0; i < msgCount; i++)
        { //go through each received msg
            string sender = senders[i];
            string msg = (string)messages[i];
            chat.text = chat.text +"\n" + (sender + ": " + msg);
            Debug.Log(sender + ": " + msg);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
       
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
       
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("Subscribed to a new channel!");
    }

    public void OnUnsubscribed(string[] channels)
    {
       
    }

    public void OnUserSubscribed(string channel, string user)
    {
      
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
  
    }
    void OnApplicationQuit()
    {
        if (chatClient != null) { chatClient.Disconnect(); }
    }
    #endregion 
    void Start()
    {
        userId = GameController.Instance.UIController.GetPlayerName();
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new Photon.Chat.AuthenticationValues(userId));
        sendButton.onClick.AddListener(OnClickSend);
    }

    void Update()
    {
        if (chatClient != null) { 
            chatClient.Service(); 
        }
    }

    public void OnEnterSend()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            this.SendMessage(this.inputField.text);
            this.inputField.text = "";
        }
    }

    public void OnClickSend()
    {
        if (this.inputField != null)
        {
            this.SendMessage(this.inputField.text);
            this.inputField.text = "";
        }
    }
    public void SendMessage(string message)
    {
        chatClient.PublishMessage(GameController.Instance.UIController.GetRoomName(), message);
    }
}
