using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    private GameObject camFocus;

    public DoorProperties doorProperty;

    public int doorType;

    CamMovement camMovement;

    void Start()
    {
        camFocus = GameObject.Find("camFocus");
        camMovement = camFocus.GetComponent<CamMovement>();
        doorType = doorProperty.doorType;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(characterTriggerDisable(other));
            camMovement.Move(doorType);
        }
    }

    IEnumerator characterTriggerDisable(Collider2D playerTrigger)
    {
        yield return new WaitForSeconds(0.2f);
        playerTrigger.enabled = false;
        yield return new WaitForSeconds(1);
        playerTrigger.enabled = true;
    }
}
