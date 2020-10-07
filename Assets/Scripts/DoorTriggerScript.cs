using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    GameObject Door;

    public void Start()
    {
        Door = GameObject.FindGameObjectWithTag("Door");
    }
    private void OnTriggerEnter(Collider other)
    {
        OpenDoor ods = Door.GetComponent<OpenDoor>();
        if (!ods.IsOpen)
        {
            StartCoroutine(ods.Open_Door());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        OpenDoor ods = Door.GetComponent<OpenDoor>();
        if (ods.IsOpen)
        {
            StartCoroutine(ods.Close_Door());
        }
    }
}
