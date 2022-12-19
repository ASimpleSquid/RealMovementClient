using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject character;
    List<Player> players;
    Directions current;

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
        Directions New = Directions.Stop;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {


            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                New = Directions.NE;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                New = Directions.NW;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                New = Directions.SE;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                New = Directions.SW;
            }
            else if (Input.GetKey(KeyCode.D))
                New = Directions.E;
            else if (Input.GetKey(KeyCode.A))
                New = Directions.W;
            else if (Input.GetKey(KeyCode.W))
                New = Directions.N;
            else if (Input.GetKey(KeyCode.S))
                New = Directions.S;
        }

        if(current != New)
        {
            current = New;
            NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.movement:D},{current:D}");
        }


    }

}

