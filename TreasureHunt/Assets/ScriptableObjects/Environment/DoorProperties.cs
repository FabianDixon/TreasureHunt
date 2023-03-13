using UnityEngine;

[CreateAssetMenu(fileName = "DoorProperties", menuName = "ScriptableObjects/DoorProperties")]

public class DoorProperties : ScriptableObject
{
    public int doorType;
    public bool originalDoor;
}
