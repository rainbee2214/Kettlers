using UnityEngine;
using System.Collections;

public class Space 
{
    public Vector2 index;
    public bool occupied;
    public string name;

    public Space(Vector2 index, bool occupied, string name = "")
    {
        this.index = index;
        this.occupied = occupied;
        this.name = name;
    }

    public override string ToString()
    {
        return ("Position (" +index.x + ","+index.y + ")"
            + " Occupied: " + occupied + ((name != "") ? (" Name: "+name) : ""));
    }
    
}
