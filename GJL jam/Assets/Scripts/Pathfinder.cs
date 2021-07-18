using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder
{
    internal RoomSO startRoom;
    internal RoomSO targetRoom;
    internal RoomSO currRoom;
    internal List<RoomSO> exploredRooms;
    public Pathfinder(RoomSO curr, RoomSO target)
    {
        startRoom = curr;
        targetRoom = target;
    }

    public List<RoomSO> SearchPath()
    {

        currRoom = startRoom;
        exploredRooms.Add(startRoom);
        Dot dotInit = new Dot(startRoom, 0);
        Dot fin = SearchAlg(0, dotInit);
        List<RoomSO> pathToTarget = GetTheRoomPathList(fin);

        return pathToTarget;
    }

    internal Dot SearchAlg(int cost, Dot dotBefore)
    {
        foreach(RoomSO room in currRoom.neighborRooms)
        {
            if (!exploredRooms.Contains(room))
            {
                int newCost = cost++;
                Dot dot = new Dot(room, newCost, dotBefore);
                exploredRooms.Add(room);
                if (room != targetRoom)
                {
                    currRoom = room;
                    SearchAlg(newCost, dot);
                }
                else
                {
                    return dot;
                }
            }
            
        }
        return null;
    }

    internal List<RoomSO> GetTheRoomPathList(Dot dot)
    {
        List<RoomSO> path = new List<RoomSO>();
        path.Insert(0, dot.roomDot);

        while(dot.isHead != true)
        {
            dot = dot.dotBefore;
            path.Insert(0, dot.roomDot);
        }


        return path;
    }

}
