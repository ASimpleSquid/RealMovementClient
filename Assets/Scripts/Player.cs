using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    Vector2 characterPositionInPercent;
    Vector2 characterVelocityInPercent;
    public static readonly float CharacterSpeed = 0.25f;
    public static readonly float DiagonalCharacterSpeed = Mathf.Sqrt(CharacterSpeed * CharacterSpeed + CharacterSpeed * CharacterSpeed) / 2f;

    void Start()
    {
        Sprite circleTexture = Resources.Load<Sprite>("Circle");

        this.gameObject.AddComponent<SpriteRenderer>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = circleTexture;

        characterPositionInPercent = new Vector2(.5f, .5f);
        characterVelocityInPercent = Vector2.zero;
    }

    void Update()
    {
        characterPositionInPercent += (characterVelocityInPercent * Time.deltaTime);

        Vector2 screenPos = new Vector2(characterPositionInPercent.x * (float)Screen.width, characterPositionInPercent.y * (float)Screen.height);
        Vector3 characterPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0));
        characterPos.z = 0;
        this.transform.position = characterPos;
    }
}
