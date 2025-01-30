using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public GameObject characterPrefab;  // Assign the prefab here
    public Sprite characterIcon;        // Icon for the selection screen
    public string characterDescription; // Optional: a brief description of the character
}
