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

            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {

            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {

            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {

            }
            else if (Input.GetKey(KeyCode.D)) ;

            else if (Input.GetKey(KeyCode.A)) ;


            else if (Input.GetKey(KeyCode.W)) ;


            else if (Input.GetKey(KeyCode.S)) ;
          
        }

    }

}

