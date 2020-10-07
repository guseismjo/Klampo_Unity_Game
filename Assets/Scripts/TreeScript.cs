using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public int woodAmount;
    public bool readyToCut;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private CapsuleCollider treeCollider;
    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        //woodAmount = 50;
        initialPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        initialRotation = Quaternion.Euler(transform.localRotation.x, transform.rotation.y, transform.localRotation.z);

        treeCollider = gameObject.GetComponent<CapsuleCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();

        rb.useGravity = false;
        readyToCut = true;
        
        Debug.Log("Resetting tree to transform.localposition: " + initialPosition);
        Debug.Log("Resetting tree to transform.localrotation: " + initialRotation);
    }


    public void CutTreeDown()
    {
        Quaternion newRotation = Quaternion.Euler(initialRotation.x-2, initialRotation.y, initialRotation.z);
        transform.localRotation = newRotation;
        rb.useGravity = true;
        rb.isKinematic = false;
        readyToCut = false;
        audioSource.Play();
        StartCoroutine(RemoveTree());
        
    }

    private IEnumerator RemoveTree()
    {
        yield return new WaitForSeconds(8);
        transform.localPosition = new Vector3(1000, 1000, 1000); //tmp to remove tree
        StartCoroutine(GrowTree());
    }

    private IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(120);
        ResetTree();

    }

    private void ResetTree()
    {
        Debug.Log("Resetting tree to transform.localposition: " + initialPosition);
        Debug.Log("Resetting tree to transform.localrotation: " + initialRotation);
        rb.isKinematic = true;
        rb.useGravity = false;
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        woodAmount = 50;
        readyToCut = true;
    }

    public void DecWoodAmount()
    {
        woodAmount--;
    }



}
