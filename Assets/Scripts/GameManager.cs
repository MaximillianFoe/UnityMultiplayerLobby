using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using TMPro;

public class GameManager : GlobalEventListener
{
    public TextMeshProUGUI chatBoard;

    public override void SceneLoadLocalDone(string scene)
    {
        // randomize a position
        var spawnPosition = new Vector3(Random.Range(-4, 4), 0.5f, 0);

        // instantiate cube
        BoltNetwork.Instantiate(BoltPrefabs.PlayerObject, spawnPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SendMessage();
        }
        
    }

    void SendMessage()
    {
        var message = PlayerChatEvent.Create();
        message.ChatMessage = "Z pressed";
        message.Send();
    }

    public override void OnEvent(PlayerChatEvent evnt)
    {
        chatBoard.text = evnt.ChatMessage;
    }
}
