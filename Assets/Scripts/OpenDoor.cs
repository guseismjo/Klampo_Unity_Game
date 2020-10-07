using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private float StartAng;
    private float EndAng;
    private float NewValue;
    public float RotOffset;
    public bool IsOpen;
    public Transform trans;

    public void Start()
    {
        StartAng = 0.16f;
        EndAng = -80.0f;
        IsOpen = false;
        NewValue = trans.localRotation.y;
    }

    public IEnumerator Open_Door()
    {
        
        while (NewValue > EndAng)
        {
            yield return new WaitForSeconds(0.0001f);
            NewValue = NewValue - RotOffset;
            trans.localRotation = Quaternion.Euler(0, NewValue, 0);
        }
        
        IsOpen = true;
    }

    public IEnumerator Close_Door()
    {
        while (NewValue < StartAng)
        {
            yield return new WaitForSeconds(0.0001f);
            NewValue = NewValue + RotOffset;
            trans.localRotation = Quaternion.Euler(0, NewValue, 0);
        }
        IsOpen = false;
    }
}
