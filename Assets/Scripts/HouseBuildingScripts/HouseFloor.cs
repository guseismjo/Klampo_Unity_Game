using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFloor : MonoBehaviour
{
    private GameObject side1;
    private GameObject side2;
    private MaterialScript matScrip;
    private int reqMat1;
    private int reqMat2;
    private bool side1Done;
    private bool side2Done;

    public bool isBuilt;

    void Start() {
        side1 = transform.GetChild(0).gameObject;
        side1.SetActive(false);
        side2 = transform.GetChild(1).gameObject;
        side2.SetActive(false);
        reqMat1 = 25;
        reqMat2 = 25;
        isBuilt = false;
        side1Done = false;
        side2Done = false;
        matScrip = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MaterialScript>();
    }

    public void Build(int mat)
    {
        if (mat >= reqMat1 && !side1Done && !side2Done)
        {
            side1.SetActive(true);
            matScrip.RemoveWood(reqMat1);
            side1Done = true;
        }
        else if (mat >= reqMat2 && side1Done && !side2Done)
        {
            side2.SetActive(true);
            matScrip.RemoveWood(reqMat2);
            side2Done = true;
        }
        else StartCoroutine(matScrip.DisplayNotification("Not enough wood"));

        if (side2Done && side1Done) isBuilt = true;
    }


}
