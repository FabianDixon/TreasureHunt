using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private GameObject parent;

    public int doorID;

    SpawnRoom spawnRoomScript;

    void Start()
    {
        parent = this.gameObject.transform.parent.gameObject;
        doorID = parent.GetComponent<RoomChange>().doorType;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomOrigin"))
        {
            Destroy(this.gameObject.transform.parent.gameObject.GetComponent<SpawnRoom>());
            Destroy(this.gameObject);
        }

        if (other.CompareTag("RoomSpawnPoint"))
        {
            spawnRoomScript = parent.GetComponent<SpawnRoom>();
            spawnRoomScript.collidingSpawners(other.gameObject.GetComponent<RoomDestroyer>().doorID);
        }
    }
}
