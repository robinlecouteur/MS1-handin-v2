using Assets.model;
using Assets.model.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area
{
    public Area()
    {
        TimesVisited = 0;
    }

    //------------------------------------------------------------------- VARIABLES ---------------------------------------------------------------------//
    //                                                                                                                                                   //
    //                                                                                                                                                   //

        //### Declare Vars ###
            protected Players _players = new Players();     //stores what players are currently in the area?
            protected Area[] _connectedAreas = new Area[4]; //Stores a list of areas that are connected to this area
            protected string _areaName = "areaName placeholder";    //Stores the name of the area  
            protected Dictionary<string, string> _dictAreaText   //Dictionary containing different lines of text
                = new Dictionary<string, string>();              //These lines of text can be added to the _areaText depending on conditions
            protected string _areaText = "";    //Stores the text that will be displayed for this area
            protected List<Item> _lstAreaItems = new List<Item>();
            //protected Dictionary<string, Item> _dictAreaItems = new Dictionary<string, Item>();//Stores a list of items that are in the area
            protected int _timesVisited;
            protected bool _hasBeenVisited;
        //###---


        //### Properties ###
    
            //*** Properties for each direction ***//
            public Area North
            {
                get
                {
                    return _connectedAreas[(int)GameModel.DIRECTION.North];
                }
                set
                {
                    _connectedAreas[(int)GameModel.DIRECTION.North] = value;
                }
            }
            public Area South
            {
                get
                {
                    return _connectedAreas[(int)GameModel.DIRECTION.South];
                }
                set
                {
                    _connectedAreas[(int)GameModel.DIRECTION.South] = value;
                }
            }   
            public Area East
            {
                get
                {
                    return _connectedAreas[(int)GameModel.DIRECTION.East];
                }
                set
                {
                    _connectedAreas[(int)GameModel.DIRECTION.East] = value;
                }
            }
            public Area West
            {
                get
                {
                    return _connectedAreas[(int)GameModel.DIRECTION.West];
                }
                set
                {
                    _connectedAreas[(int)GameModel.DIRECTION.West] = value;
                }
            }
            //***   ***   ***   ***   ***   ***   *//

            public Dictionary<string, string> DictAreaText
            {
                get
                {
                    return _dictAreaText;
                }

                set
                {
                    _dictAreaText = value;
                }
            }
            public List<Item> LstAreaItems
            {
                get
                {
                    return _lstAreaItems;
                }

                set
                {
                    _lstAreaItems = value;
                }
            }
            public int TimesVisited
            {
                get
                {
                    return _timesVisited;
                }

                set
                {
                    _timesVisited = value;
                }
            }
            public string Directions
            {
                get
                {
                    string lcDirections = "\n \n This is where you can go from here: \n";
                    if (North != null){ lcDirections +=  "   North: " + North.AreaName + "\n"; }
                    if (South != null) { lcDirections += "   South: " + South.AreaName + "\n"; }
                    if (East != null) { lcDirections +=  "   East:  " + East.AreaName + "\n"; }
                    if (West != null) { lcDirections +=  "   West:  " + West.AreaName + "\n"; }

                    return lcDirections;
                }
            }
            public string AreaText
            {
                get
                {
                    return _areaText;
                }

                set
                {
                    _areaText = value;
                }
            }
            public string AreaName
            {
                get
                {
                    return _areaName;
                }

                set
                {
                    _areaName = value;
                }
            }
        //###---

    //                                                                                                                                                   //
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//



    //------------------------------------------------------------------ METHODS ------------------------------------------------------------------------//
    //                                                                                                                                                   //
    //                                                                                                                                                   //
    public virtual void Arrive()
    {
        AreaText += DictAreaText["DefaultText"];
        AreaText += Directions;
    }

    public virtual void Leave()
    {
        _timesVisited += 1;
        _areaText = "";
    }  
    //                                                                                                                                                   //
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//

}
