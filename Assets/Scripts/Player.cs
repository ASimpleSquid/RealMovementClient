using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int id;
    Vector2 characterPositionInPercent;
    Vector2 characterVelocityInPercent;
    public static readonly float CharacterSpeed = 0.25f;
    public static readonly float DiagonalCharacterSpeed = Mathf.Sqrt(CharacterSpeed * CharacterSpeed + CharacterSpeed * CharacterSpeed) / 2f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
