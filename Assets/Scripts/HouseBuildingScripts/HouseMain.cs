using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMain : MonoBehaviour
{
    private HouseFoundation houseFo;
    private HouseFloor houseFl;
    private HouseWalls houseW;
    private HouseRoof houseR;
    private MaterialScript matScrip;
    private int ownedStone;
    private int ownedWood;
    private int activeBuild;

    public void Start()
    {
        houseFo = transform.GetChild(0).GetComponent<HouseFoundation>();
        houseFl = transform.GetChild(1).GetComponent<HouseFloor>();
        houseW = transform.GetChild(2).GetComponent<HouseWalls>();
        houseR = transform.GetChild(3).GetComponent<HouseRoof>();
        activeBuild = 1;
        matScrip = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MaterialScript>();
    }

    public void BuildSomething()
    {
        ownedWood = matScrip.GetWood();
        ownedStone = matScrip.GetStone();
        if (activeBuild == 1) BuildFoundation();
        else if (activeBuild == 2) BuildFloor();
        else if (activeBuild == 3) BuildWalls();
        else if (activeBuild == 4) BuildRoof();
        else if (activeBuild == 5) StartCoroutine(matScrip.DisplayNotification("House is finished!"));
    }

    private void BuildFoundation()
    {
        houseFo.Build(ownedStone);
        if (houseFo.isBuilt)
        {
            activeBuild = 2;
        }
    }

    private void BuildFloor()
    {
        houseFl.Build(ownedWood);
        if (houseFl.isBuilt)
        {
            activeBuild = 3;
        }
    }

    private void BuildWalls()
    {
        houseW.Build(ownedWood);
        if (houseW.isBuilt)
        {
            activeBuild = 4;
        }
    }

    private void BuildRoof()
    {
        houseR.Build(ownedWood, ownedStone);
        if (houseR.isBuilt) activeBuild = 5;
    }






}
