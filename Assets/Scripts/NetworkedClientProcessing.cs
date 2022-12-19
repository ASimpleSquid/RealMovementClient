using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkedClientProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromServer(string msg)
    {
        Debug.Log("msg received = " + msg + ".");

        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[0]);

        switch ((ServerToClientSignifiers)signifier)
        {
            case ServerToClientSignifiers.connect:
                gameLogic.CreatePlayer(Int32.Parse(csv[1]));
                break;
            case ServerToClientSignifiers.disconnect:
                gameLogic.DestroyPlayer(Int32.Parse(csv[1]));
                break;
            case ServerToClientSignifiers.updatePlayer:
                string[] parts = csv[1].Split('_');
                Vector2 Position = new Vector2(Single.Parse(parts[0]),Single.Parse(parts[1]));
                Vector2 Velocity = new Vector2(Single.Parse(parts[2]),Single.Parse(parts[3]));
                gameLogic.UpdatePlayer(Position, Velocity, Int32.Parse(parts[4]));
                break;

            default:
                break;
        }

    }

    static public void SendMessageToServer(string msg)
    {
        networkedClient.SendMessageToServer(msg);
    }

    #endregion

    #region Connection Related Functions and Events
    static public void ConnectionEvent()
    {
        Debug.Log("Network Connection Event!");
    }
    static public void DisconnectionEvent()
    {
        Debug.Log("Network Disconnection Event!");
    }
    static public bool IsConnectedToServer()
    {
        return networkedClient.IsConnected();
    }
    static public void ConnectToServer()
    {
        networkedClient.Connect();
    }
    static public void DisconnectFromServer()
    {
        networkedClient.Disconnect();
    }

    #endregion

    #region Setup
    static NetworkedClient networkedClient;
    static GameLogic gameLogic;

    static public void SetNetworkedClient(NetworkedClient NetworkedClient)
    {
        networkedClient = NetworkedClient;
    }
    static public NetworkedClient GetNetworkedClient()
    {
        return networkedClient;
    }
    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }

    #endregion

}

#region Protocol Signifiers
public enum ClientToServerSignifiers
{
    asd,
    movement
}

public enum ServerToClientSignifiers
{
    asd,
    connect,
    disconnect,
    updatePlayer
}

public enum Directions
{
    Stop,
    N,
    NE,
    E,
    SE,
    S,
    SW,
    W,
    NW
}


#endregion

