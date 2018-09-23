using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.model.Items;

public delegate void aDisplayer(String value);

public class CommandProcessor
{
    public CommandProcessor()
    {
    }

    public void Parse(String pCmdStr, aDisplayer display)
    {

        //List index[0] = text if no SceneObject is present
        //List index[1] = text after SceneObject is picked up
        //List index[2] = text if a SceneObject is present
        String strResult = "Do not understand";
        Area lcCurrentArea = GameModel.CurrentPlayer.CurrentArea;

        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        if (parts.Length > 0)
        {


            // process the tokens
            switch (parts[0])
            {
                case "pick":
                    if (parts[1] == "up")
                    {
                        Debug.Log("Got Pick up");
                        if (GameModel.CurrentPlayer.CurrentArea.LstAreaItems.Count != 0)
                        {
                            foreach (Item prItem in GameModel.CurrentPlayer.CurrentArea.LstAreaItems)
                            {
                                if (parts[2] == prItem.Name)
                                {
                                    GameModel.Pickup(prItem);
                                    GameModel.RemoveItemFromArea(prItem);
                                    strResult = prItem.TextOnPickup;
                                    break;
                                } 
                            }
                            
                        }
                        else
                        {
                            strResult = "There is nothing to pick up";
                        }

                        if (parts.Length == 3)
                        {
                            String param = parts[2];
                        }// do pick up command
                    }
                    display(strResult);
                    break;
                case "go":
                    GameModel.DIRECTION lcDirection;
                    switch (parts[1])
                    {
                        case "north":
                            Debug.Log("Got go North");
                            lcDirection = GameModel.DIRECTION.North;
                            GoDirection(lcCurrentArea, lcDirection);

                            strResult = Arrive(lcCurrentArea, strResult);
                            break;

                        case "south":
                            Debug.Log("Got go South");
                            lcDirection = GameModel.DIRECTION.South;
                            GoDirection(lcCurrentArea, lcDirection);

                            strResult = Arrive(lcCurrentArea, strResult);
                            break;

                        case "east":
                            Debug.Log("Got go East");
                            lcDirection = GameModel.DIRECTION.East;
                            GoDirection(lcCurrentArea, lcDirection);

                            strResult = Arrive(lcCurrentArea, strResult);
                            break;

                        case "west":
                            Debug.Log("Got go West");
                            lcDirection = GameModel.DIRECTION.West;
                            GoDirection(lcCurrentArea, lcDirection);

                            strResult = Arrive(lcCurrentArea, strResult);
                            break;

                        default:
                            Debug.Log(" do not know how to go there");
                            strResult = "Do not know how to go there";
                            break;

                    }
                    display(strResult);
                    break;
                case "show":
                    switch (parts[1])
                    {
                        case "Game":
                            GameManager.instance.setActiveCanvas("cnvGame");
                            break;
                        case "inventory":
                            GameManager.instance.setActiveCanvas("cnvInventory");
                            break;
                        case "map":
                            GameManager.instance.setActiveCanvas("cnvMap");
                            break;
                    }


                    //call function from scene inherited scene object, two types of scenes
                    // yes/no scene
                    // pickup item scene

                    // yes/no displays different text upon yes or no
                    // pick up simply places item in your inventory array

                    //if (GameManager.instance.activeCanvas == cnvGame)

                    
                    display(strResult);
                    
                    break;
                default:
                    Debug.Log("Do not understand");
                    strResult = "Do not understand";
                    break;

            }// end switch
        }
        // return strResult;

    }// Parse

    private static string Arrive(Area lcCurrentArea,string strResult)
    {
        lcCurrentArea = GameModel.CurrentPlayer.CurrentArea;
        lcCurrentArea.Arrive();
        strResult = lcCurrentArea.AreaText;
        return strResult;
    }

    private static void GoDirection(Area lcCurrentArea, GameModel.DIRECTION lcDirection)
    {      
        lcCurrentArea.Leave();
        GameModel.go(lcDirection);
    }



}


