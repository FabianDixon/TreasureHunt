using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> roomList = new List<GameObject> { };

    private GameObject newRoom;

    private int numRoom;
    Vector2 pos;

    public DoorProperties doorProperty;

    [SerializeField]
    private bool isOriginalDoor;

    [SerializeField]
    private bool isCollidingSpawner = false;

    [SerializeField]
    private int colliderDoorID = -1;

    void Start()
    {
        isOriginalDoor = doorProperty.originalDoor;

        if (isOriginalDoor == true)
        {
            Destroy(GetComponent<SpawnRoom>());
        }
        else
        {
            numRoom = Random.Range(0, roomList.Count);
            pos = this.gameObject.transform.GetChild(0).transform.position;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            newRoom = Instantiate(roomList[numRoom], pos, Quaternion.identity);
            if (isCollidingSpawner)
            {
                StartCoroutine(colliderID(newRoom, colliderDoorID));
            }
            Destroy(GetComponent<SpawnRoom>());
        }
    }

    public void collidingSpawners(int doorID)
    {
        isCollidingSpawner = true;
        colliderDoorID = doorID;
    }

    IEnumerator colliderID(GameObject Room, int ID)
    {
        yield return new WaitForSeconds(0.1f);
        Room.GetComponent<DoorSpawner>().colliderID = ID;
    }
}