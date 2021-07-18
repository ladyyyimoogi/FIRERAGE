using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/Level", order = 3)]
public class LevelSO : ScriptableObject
{
    [SerializeField] internal string levelID;
    [SerializeField] internal List<RoomSO> roomList;
    [SerializeField] internal List<Vector2> roomPos;
}
