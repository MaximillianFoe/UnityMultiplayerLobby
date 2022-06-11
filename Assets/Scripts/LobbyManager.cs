using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt.Matchmaking;
using UdpKit;
using UdpKit.Platform;
using UdpKit.Platform.Photon;
using Bolt.Photon;
using Bolt.Utils;
using UnityEngine.SceneManagement;

public class LobbyManager : Bolt.GlobalEventListener
{
    bool isLoadingScene;

    public void OnCreateServerClicked()
    {
        BoltLauncher.StartServer();
    }

    public void OnCreateClientClicked()
    {
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone()
    {
        Debug.Log("Bolt start done");
        if (BoltNetwork.IsServer)
        {
            CreateRoom();
        }
        else
        {
            JoinRoom();
        }
    }

    void CreateRoom()
    {
        if (BoltNetwork.IsRunning && BoltNetwork.IsServer)
        {
            //PhotonRoomProperties token = new PhotonRoomProperties();

            // Start Photon Room
            BoltMatchmaking.CreateSession(
                sessionID: "SE352"//,
                                  //token: token
            );
        }
        else
        {
            Debug.Log("Server not connected");
        }

    }

    void JoinRoom()
    {
        if (BoltNetwork.IsRunning && BoltNetwork.IsClient)
        {
            BoltMatchmaking.JoinSession("SE352");
        }
        else
        {
            Debug.Log("client Not connected");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (BoltNetwork.IsServer && BoltMatchmaking.CurrentSession.ConnectionsCurrent == 2)
        {
            if (!isLoadingScene)
            {
                isLoadingScene = true;
                BoltNetwork.LoadScene("GameScene");
            }
        }
    }
}
