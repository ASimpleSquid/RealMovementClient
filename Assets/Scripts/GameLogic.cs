using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject character;

    void Start()
    {
        NetworkedClientProcessing.SetGameLogic(this);

        Sprite circleTexture = Resources.Load<Sprite>("Circle");

        character = new GameObject("Character");

        character.AddComponent<SpriteRenderer>();
        character.GetComponent<SpriteRenderer>().sprite = circleTexture;
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

        /*characterPositionInPercent += (characterVelocityInPercent * Time.deltaTime);

        Vector2 screenPos = new Vector2(characterPositionInPercent.x * (float)Screen.width, characterPositionInPercent.y * (float)Screen.height);
        Vector3 characterPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0));
        characterPos.z = 0;
        character.transform.position = characterPos;*/

    }

}

