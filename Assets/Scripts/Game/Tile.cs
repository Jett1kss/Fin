using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public bool Open;

    public int ID;
    public int LastID;

    public Tile(bool open, int id, int lastId)
    {
        Open = open;
        ID = id;
        LastID = lastId;
    }

}
