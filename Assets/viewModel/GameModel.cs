using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;
using Assets.model;
using Assets.model.Scenes;
using Assets.model.Items;

public class GameModel
{
    public GameModel()
    {
        MakeAreas();
    }
    private static Player _player = new Player();
    public enum DIRECTION { North, South, East, West };
    public static Players PlayersInGame = new Players(); 
    public static Player CurrentPlayer
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }

    }




    public static void go(DIRECTION pDirection)
    {
        _player.Move(pDirection);
    }
    public static void Pickup(Item prItem)
    {
        CurrentPlayer.LstInventory.Add(prItem);
    }

    public static void RemoveItemFromArea(Item prItem)
    {
        CurrentPlayer.CurrentArea.LstAreaItems.Remove(prItem);
    }


    public static void MakeAreas()
    { 
        //Instantiate Areas  
        Area areaTownCenter = new AreaTownCenter();
        Area areaTavern = new AreaTavern();
        Area areaFootOfMountain = new AreaFootOfMountain();
        Area areaHalfUpMountain = new AreaHalfUpMountain();
        Area areaTopOfMountain = new AreaTopOfMountain();



        //Town Center (Starting Area)
        areaTownCenter.North = null;
        areaTownCenter.South = areaTavern;
        areaTownCenter.West = areaFootOfMountain;
        areaTownCenter.East = null;

        //Tavern
        areaTavern.North = areaTownCenter;
        areaTavern.South = areaFootOfMountain;
        areaTavern.East = null;
        areaTavern.West = null;

        //areaFootOfMountain
        areaFootOfMountain.North = areaTavern;
        areaFootOfMountain.South = null;
        areaFootOfMountain.East = null;
        areaFootOfMountain.West = null;

        //areaHalfUpMountain
        areaHalfUpMountain.North = null;
        areaHalfUpMountain.South = null;
        areaHalfUpMountain.East = null;
        areaHalfUpMountain.West = null;

        //areaTopOfMountain
        areaTopOfMountain.North = null;
        areaTopOfMountain.South = null;
        areaTopOfMountain.East = null;
        areaTopOfMountain.West = null;


        //Starts player in initial area
        _player.CurrentArea = areaTownCenter;
    }
}

