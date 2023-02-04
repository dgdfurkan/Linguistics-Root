using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayVariables", menuName = "LinguisticRoot/CreateLetter")]
public class Letter : ScriptableObject
{
    public List<Lett> letters = new List<Lett>();
}
[System.Serializable]
public struct Lett
{
    public string name;
    public Sprite sprite;
}