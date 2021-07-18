using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/Room", order = 2)]
public class RoomSO : ScriptableObject
{
    [SerializeField] internal string roomID;
    [SerializeField] internal List<NodeSO> nodeSOs;
    [SerializeField] internal List<RoomSO> neighborRooms;

}
