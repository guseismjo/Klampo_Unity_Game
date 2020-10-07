using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialScript : MonoBehaviour
{
    public int nWood;  //make private
    public int nStone; //make private
    public Text textCanvas;
    public Text notificationText;

    public void Start()
    {
        //nWood = 0;
        //nStone = 0;
        textCanvas.text = "";
        notificationText.text = "";

    }
    public void IncStone()
    {
        nStone++;
        DisplayAmount();
    }
    public void IncWood()
    {
        nWood++;
        DisplayAmount();
    }

    public void RemoveStone(int amount)
    {
        nStone -= amount;
        DisplayAmount();
    }
    
    public void RemoveWood(int amount)
    {
        nWood -= amount;
        DisplayAmount();
    }

    public int GetWood()
    {
        return nWood;
    }

    public int GetStone()
    {
        return nStone;
    }

    public IEnumerator DisplayNotification(string newText)
    {
        notificationText.text = newText;
        yield return new WaitForSeconds(5);
        notificationText.text = "";
    }

    private void DisplayAmount()
    {
        textCanvas.text = "Wood: "+nWood+ "\nStone: " + nStone;
    }

    

}
