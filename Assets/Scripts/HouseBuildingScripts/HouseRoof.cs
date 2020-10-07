using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRoof : MonoBehaviour
{
    private List<GameObject> parts;
    private MaterialScript matScrip;
    private int reqMatWood;
    private int reqMatStone;
    private int order;

    public bool isBuilt;

    void Start()
    {
        parts = new List<GameObject>();

        foreach(Transform child in transform)
        {
            parts.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        reqMatWood = 15;
        reqMatStone = 15;
        order = 0;
        matScrip = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MaterialScript>();

    }

    public void Build(int matW, int matS)
    {
        if (order <= 4) BuildWood(matW);
        else if (order >= 5 && order <= 6) BuildStone(matS);
        else isBuilt = true;

    }

    private void BuildWood(int mat)
    {
        if (mat >= reqMatWood)
        {
            parts[order].SetActive(true);
            matScrip.RemoveWood(reqMatWood);
            order++;
        }
        else StartCoroutine(matScrip.DisplayNotification("Not enough wood"));
    }

    private void BuildStone(int mat)
    {
        if (mat >= reqMatStone)
        {
            parts[order].SetActive(true);
            matScrip.RemoveStone(reqMatStone);
            order++;
        }
        else StartCoroutine(matScrip.DisplayNotification("Not enough stone"));
    }


}
