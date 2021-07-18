using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] internal NodeSO so;
    internal RoomSO roomSO;
    [SerializeField] internal GameObject managerObj;

    private void Start()
    {
        roomSO = so.room;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player is in room: " + roomSO.roomID);
            string[] roomArr = roomSO.name.Split('_');
            Int32 currPlayerRoomIdx = Int32.Parse(roomArr[roomArr.Length - 1]) - 1;
            //managerObj.GetComponent<LevelManager>().SetCurrPlayerRoom(roomSO);
            EventManager.TriggerEvent("PlayerEnter", new Dictionary<string, object> { { "roomIdx", currPlayerRoomIdx }, { "roomSO", roomSO } });
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMove>().SetCurrRoom(roomSO);
            //EventManager.TriggerEvent("EnemyEnter", new Dictionary<string, object> { { "roomSO", roomSO } });
        }
    }
}
