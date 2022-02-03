using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField playerName;
    public InputField roomName;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    

    public override void OnConnectedToMaster()
    {
        nameUI.SetActive(true);
    }

    public void PlayButton()
    {
        PhotonNetwork.NickName = playerName.text;
        nameUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public void JoinOrCreateButton()
    {
        if(roomName.text.Length<2)
            return;
        loginUI.SetActive(false);

        RoomOptions options = new RoomOptions {MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
