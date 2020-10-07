using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseWalls : MonoBehaviour
{
    private GameObject pillars;
    private GameObject beams;
    private GameObject backSide;
    private GameObject waterSide;
    private GameObject mountainSide;
    private GameObject entrySide;
    private MaterialScript matScrip;
    private int reqMat1;
    private int order;
    private List<GameObject> parts;

    public bool isBuilt;
    // Start is called before the first frame update
    void Start()
    {
        parts = new List<GameObject>();

        pillars = transform.GetChild(0).gameObject;
        parts.Add(pillars);
        pillars.SetActive(false);

        beams = transform.GetChild(1).gameObject;
        parts.Add(beams);
        beams.SetActive(false);

        backSide = transform.GetChild(2).gameObject;
        parts.Add(backSide);
        backSide.SetActive(false);

        waterSide = transform.GetChild(3).gameObject;
        parts.Add(waterSide);
        waterSide.SetActive(false);

        mountainSide = transform.GetChild(4).gameObject;
        parts.Add(mountainSide);
        mountainSide.SetActive(false);

        entrySide = transform.GetChild(5).gameObject;
        parts.Add(entrySide);
        entrySide.SetActive(false);

        matScrip = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MaterialScript>();
        order = 0;
        reqMat1 = 20;
    }

    public void Build(int mat)
    {
        if (mat >= reqMat1 && order <= 5)
        {
            parts[order].SetActive(true);
            matScrip.RemoveWood(reqMat1);
            order++;
        }
        else StartCoroutine(matScrip.DisplayNotification("Not enough wood"));

        if (order == 6) isBuilt = true;
    }
}
