using Assets.model.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    public Text output;
    

    void Update()
    {
        output.text = null;
        output.text = "* INVENTORY * \n \n";

        if (GameModel.CurrentPlayer.LstInventory != null)
        {        
            foreach (Item prItem in GameModel.CurrentPlayer.LstInventory)
            {
                output.text = output.text + "\n" + prItem.Name;
            }
        }
        else
        {
            output.text = "Your inventory is empty!";
        }
    }
}
