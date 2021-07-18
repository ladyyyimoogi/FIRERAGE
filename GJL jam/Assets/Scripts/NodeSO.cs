using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/Node", order = 1)]
public class NodeSO : ScriptableObject
{
    [SerializeField] internal string nodeID; //LEVEL_ROOM_NO
    [SerializeField] internal RoomSO room; //LEVEL_ROOM
    internal string roomID;


    private void setRoomID()
    {
        roomID = room.roomID;
    }
}
