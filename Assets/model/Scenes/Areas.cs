using Assets.model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.model.Scenes
{




    //---------------------------------------------------------------- Town Center ----------------------------------------------------------------------//
    //                                                                                                                                                   //
    public class AreaTownCenter : Area
    {     
        public AreaTownCenter()
        {
            _areaName = "Town Center";         
            _dictAreaText.Add("DefaultText", "Town Center");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //------------------------------------------------------------------ Tavern -------------------------------------------------------------------------//
    //                                                                                                                                                   //
    public class AreaTavern : Area
    {
        public AreaTavern()
        {
            _areaName = "Tavern";
            _lstAreaItems.Add(new Item {Name = "goldcoin", Description = "A shiny gold coin", TextOnPickup  = "You quickly pocket the coin of precious gold" });

            //*** Add Text ***//
            _dictAreaText.Add("DefaultText", "You arrive at the Tavern.");
            _dictAreaText.Add("GoldCoinText", "you see a GoldCoin on the ground. Type 'pick up goldcoin' to pick it up.");
            _dictAreaText.Add("ReturningText", "You return to the Tavern.");
            //***   ***   *** //
        }

        public override void Arrive()
        {
            if (_timesVisited == 0)
            { _areaText += _dictAreaText["DefaultText"] + "\n"; }
            else if (_timesVisited >= 1)
            { _areaText += _dictAreaText["ReturningText"]; }



            foreach (Item prItem in _lstAreaItems)
            {
                if (prItem.Name == "goldcoin") { _areaText += _dictAreaText["GoldCoinText"] + "\n";}
            }


            _areaText += Directions;
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //-------------------------------------------------------------- Foot of Mountain -------------------------------------------------------------------//
    //                                                                                                                                                   //
    public class AreaFootOfMountain : Area
    {
        public AreaFootOfMountain()
        {
            _areaName = "Foot of the mountain";
            _dictAreaText.Add("DefaultText", "You are at the foot of the mountain");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //------------------------------------------------------------- Half Up Mountain --------------------------------------------------------------------//
    //                                                                                                                                                   //
    public class AreaHalfUpMountain : Area
    {
        public AreaHalfUpMountain()
        {
            _areaName = "Half way up the Mountain";
            _dictAreaText.Add("DefaultText", "Halfway up the mountain");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //-------------------------------------------------------------- Top of Mountain --------------------------------------------------------------------//
    //                                                                                                                                                   //
    public class AreaTopOfMountain : Area
    {
        public AreaTopOfMountain()
        {
            _areaName = "Top of the Mountain";
            _dictAreaText.Add("DefaultText", "Top of the mountain");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//
}
