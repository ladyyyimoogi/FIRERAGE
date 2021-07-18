using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Dot : Object
{
    internal RoomSO roomDot;
    internal int cost;
    internal Dot dotBefore;
    internal List<RoomSO> neighborRoom = new List<RoomSO>();
    internal bool isHead;
    

    public Dot(RoomSO so, int cost, Dot dotBefore = null)
    {
        roomDot = so;
        this.cost = cost;
        this.dotBefore = dotBefore;
        isHead = dotBefore != null ? false : true;
        foreach (RoomSO room in roomDot.neighborRooms)
        {
            neighborRoom.Add(room);
        }
    }


}
