using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject character;
    List<Player> players;

    public void CreatePlayer(int id)
    {
        GameObject playerobj = new GameObject("Player");
        Player player = playerobj.AddComponent<Player>();
        player.id = id;
        players.Add(player);
    }

    public void DestroyPlayer(int id)
    {
        Player player = players.Find(player => player.id == id);
        players.RemoveAll(player => player.id == id);
        Destroy(player.gameObject);
    }

    public void UpdatePlayer(Vector2 Position, Vector2 Velocity, int id)
    {
        Player player = players.Find(player => player.id == id);
        player.characterPositionInPercent = Position;
        player.characterVelocityInPercent = Velocity;
    }

    void Start()
    {
        players = new List<Player>();
        NetworkedClientProcessing.SetGameLogic(this);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {


            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.NE:D}");
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.NW:D}");
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.SE:D}");
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.SW:D}");
            }
            else if (Input.GetKey(KeyCode.D))
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.E:D}");
            else if (Input.GetKey(KeyCode.A))
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.W:D}");
            else if (Input.GetKey(KeyCode.W))
            NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.N:D}");
            else if (Input.GetKey(KeyCode.S))
                NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{Directions.S:D}");
        }

    }

}

