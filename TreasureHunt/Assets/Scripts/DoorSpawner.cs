using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] doorFix;
    public GameObject[] originalDoors;

    private GameObject[] Spawn;

    private int randNumDoors;
    private int randDoorPos;

    [SerializeField]
    private List<int> doorType = new List<int> { 0, 1, 2, 3 };
    [SerializeField]
    private List<int> doorFixType = new List<int> { 0, 1, 2, 3 };
    [SerializeField]
    private int openingDirection;
    //0 -> Top door
    //1 -> Right door
    //2 -> Bottom door
    //3 -> Left door

    public int colliderID = -1;

    private GameObject child;
    private string doorTag;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        if (openingDirection != -1)
        {
            doorType.RemoveAt(openingDirection);
            doorFixType.RemoveAt(openingDirection);

            doorTag = string.Format("DoorSpawn{0}", openingDirection);
            Destroy(GameObject.FindGameObjectWithTag(doorTag));
        }

        Invoke("startSpawningDoors", 0.2f);
    }

    void DoorsToSpawn()
    {
        randNumDoors = Random.Range(1, doorType.Count + 1); //limite superior exclusivo e inferior inclusivo.
        for (int i = 0; i < randNumDoors; i++)
        {
            randDoorPos = Random.Range(0, doorType.Count);
            spawnDoor(doorType[randDoorPos], 0);
            doorType.RemoveAt(randDoorPos);
            doorFixType.RemoveAt(randDoorPos);
        }

        for (int i = 0; i < doorFixType.Count; i++)
        {
            spawnDoor(doorFixType[i], 1);
        }
    }

    void spawnDoor(int doorPos, int door)
    {
        doorTag = string.Format("DoorSpawn{0}", doorPos);

        switch (door)
        {
            case 0:
                Spawn = doors;
                break;
            case 1:
                Spawn = doorFix;
                break;
            case 2:
                Spawn = originalDoors;
                break;
        }

        pos = GameObject.FindGameObjectWithTag(doorTag).transform.position;
        child = Instantiate(Spawn[doorPos], pos, Quaternion.identity);
        child.transform.parent = transform;

        Destroy(GameObject.FindGameObjectWithTag(doorTag));
    }

    void startSpawningDoors()
    {

        if (colliderID != -1)
        {
            doorType.RemoveAt(colliderID);
            doorFixType.RemoveAt(colliderID);

            spawnDoor(colliderID, 2);
        }

        DoorsToSpawn();
    }
}
