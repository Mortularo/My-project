using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.UI;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject _lobbyContainer;
    [SerializeField] private GameObject _gameMenuContainer;
    [SerializeField] private GameObject _launcherContainer;
    
    [SerializeField] private TMP_Text _connectionStatus;

    [SerializeField] private Button _connectBttn;
    [SerializeField] private Button _multiplayerBttn;
    [SerializeField] private Button _enterRoomBttn;
    [SerializeField] private Button _exitBttn;


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        _launcherContainer.SetActive(true);
    }

    private void Update()
    {
        _connectBttn.onClick.AddListener(Connect);
        _multiplayerBttn.onClick.AddListener(LobbyEnter);
        _exitBttn.onClick.AddListener(Disconnect);
        _enterRoomBttn.onClick.AddListener(OnJoinedRoom);
    }

    private void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            _connectionStatus.SetText("Подключение успешно");
            return;
        }
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = Application.version;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectToMaster");
        //PhotonNetwork
        _launcherContainer.SetActive(false);
        _gameMenuContainer.SetActive(true);
        _lobbyContainer.SetActive(false);
    }

    public void LobbyEnter()
    {
        _launcherContainer.SetActive(false);
        _gameMenuContainer.SetActive(false);
        _lobbyContainer.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Disconnect");
        _launcherContainer.SetActive(true);
        _gameMenuContainer.SetActive(false);
        _lobbyContainer.SetActive(false);
        _connectionStatus.SetText("Статус подключения...");
    }

}
