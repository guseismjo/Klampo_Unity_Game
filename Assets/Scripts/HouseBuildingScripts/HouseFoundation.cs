using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFoundation : MonoBehaviour
{
    private GameObject startFoundation;
    private GameObject restFoundation;
    private int reqMat;
    private MaterialScript matScrip;
    public bool isBuilt;

    void Start()
    {
        startFoundation = transform.GetChild(0).gameObject;
        restFoundation = transform.GetChild(1).gameObject;

        startFoundation.SetActive(true);
        restFoundation.SetActive(false);
        reqMat = 50;
        isBuilt = false;

        matScrip = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MaterialScript>();
    }

    public void Build(int mat)
    {
        Debug.Log("Materail to build found: " + mat);
        if (mat >= reqMat)
        {
            this.gameObject.SetActive(true);
            restFoundation.SetActive(true);
            matScrip.RemoveStone(reqMat);
            isBuilt = true;
        }
        else StartCoroutine(matScrip.DisplayNotification("Not enough stone"));
    }




}
