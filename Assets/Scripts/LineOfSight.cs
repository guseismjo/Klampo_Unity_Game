using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineOfSight : MonoBehaviour
{
    private RaycastHit vision;
    private MaterialScript ms;
    private Text collectText;
    private HouseMain house;
    private AxeChopScript axeScript;
    private float timeBetweenChops;
    private bool readyToChop;

    public float rayLength;
    public GameObject collectGO;
    public GameObject Door;
    public GameObject axeHead;
    public GameObject pickaxeHead;


    void Start()
    {
        rayLength = 1.0f;
        ms = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MaterialScript>();
        collectText = collectGO.GetComponentInChildren<Text>();
        collectGO.SetActive(false);
        //Door = GameObject.FindGameObjectWithTag("Door");
        house = GameObject.FindGameObjectWithTag("House").GetComponent<HouseMain>();
        axeScript = GameObject.FindGameObjectWithTag("Axe").GetComponent<AxeChopScript>();
        timeBetweenChops = 0.8f; //axeScript.GetAnimator().length + 
        readyToChop = true;

    }

    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);
        
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength))
        {
            //Debug.Log("I hit: "+vision.collider.name);
            
            if (vision.collider.tag == "InteractiveWood")
            {
                CollectWood();
            }
            else if (vision.collider.tag == "InteractiveStone")
            {
                CollectStone();
            }else if(vision.collider.tag == "Door")
            {
                OpenDoor();
            }else if(vision.collider.tag == "Workbench"){
                UseWorkbench();
            }
            else
            {
                collectGO.SetActive(false);
            }
        }
        else
        {
            collectGO.SetActive(false);
        }
    }

    private void CollectWood()
    {
        collectGO.SetActive(true);
        axeHead.SetActive(true);
        pickaxeHead.SetActive(false);
        collectText.text = "Collect wood\n(E)";

        if (Input.GetKeyDown(KeyCode.E) && vision.transform.gameObject.GetComponent<TreeScript>().woodAmount > 0)
        {
            if (vision.transform.gameObject.GetComponent<TreeScript>().readyToCut && readyToChop)
            {
                axeScript.StartWoodAnimation();
                ms.IncWood();
                vision.transform.gameObject.GetComponent<TreeScript>().DecWoodAmount();
                StartCoroutine(WaitChop());
            }
           
        }else if(Input.GetKeyDown(KeyCode.E) && vision.transform.gameObject.GetComponent<TreeScript>().woodAmount <= 0)
        {
            if (vision.transform.gameObject.GetComponent<TreeScript>().readyToCut && readyToChop)
            {
                axeScript.StartWoodAnimation();
                vision.transform.gameObject.GetComponent<TreeScript>().CutTreeDown();
                StartCoroutine(WaitChop());
            }
        }
    }

    public IEnumerator WaitChop()
    {
        readyToChop = false;
        yield return new WaitForSeconds(timeBetweenChops);
        readyToChop = true;
    }

    private void CollectStone()
    {
        collectGO.SetActive(true);
        axeHead.SetActive(false);
        pickaxeHead.SetActive(true);
        collectText.text = "Collect stone\n(E)";

        if (Input.GetKeyDown(KeyCode.E) && readyToChop)
        {
            axeScript.StartStoneAnimation();
            ms.IncStone();
            StartCoroutine(WaitChop());
        }
    }

    private void OpenDoor()
    {
        collectGO.SetActive(true);
        collectText.text = "Use door\n(E)";

        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor ods = Door.GetComponent<OpenDoor>();
            if (!ods.IsOpen)
            {
                StartCoroutine(ods.Open_Door());
            }
            else
            {
                StartCoroutine(ods.Close_Door());
            }
        }
    }

    private void UseWorkbench()
    {
        collectGO.SetActive(true);
        collectText.text = "Use workbench\n(E)";
        if (Input.GetKeyDown(KeyCode.E))
        {
            house.BuildSomething();
        }
    }
}

