using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    [SerializeField] internal LevelSO currLevelSO;
    internal RoomSO currPlayerRoom;
    internal int currPlayerRoomIdx;
    [SerializeField] internal bool tutorialLevel = false;
    [SerializeField] internal DialogListSO tutorialSO;

    internal string lastHitStr;


    private void Awake()
    {
        currPlayerRoom = currLevelSO.roomList.ElementAt(0);
        currPlayerRoomIdx = 0;
    }

    private void Start()
    {
        if (tutorialLevel == true) { EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Press 'Enter' to see what are they going to say next" } }); }
        EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Use 'WASD' or 'IJKL' to move" } });
        EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Use 'Space' or 'Right-Click' to shoot" } });
        EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "You can change where you're facing based on mouse position" } });
        if (tutorialLevel == true)
        {
            EventManager.TriggerEvent("SendDialog", new Dictionary<string, object> { { "listSO", tutorialSO } });
            EventManager.TriggerEvent("SetHUDOil", new Dictionary<string, object> { { "val", false } });
        }
    }

    private void OnEnable()
    {
        EventManager.StartListening("PlayerEnter", OnPlayerEnter);
        EventManager.StartListening("AskRoomPosList", OnAskRoomPosList);
        EventManager.StartListening("EndScene", OnEndScene);
        EventManager.StartListening("LastHit", OnLastHit);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlayerEnter", OnPlayerEnter);
        EventManager.StopListening("AskRoomPosList", OnAskRoomPosList);
        EventManager.StopListening("EndScene", OnEndScene);
        EventManager.StopListening("LastHit", OnLastHit);
    }

    public void SetCurrPlayerRoom(RoomSO room)
    {
        //currPlayerRoom = room;
        //string[] roomArr = room.name.Split('_');
        //currPlayerRoomIdx = Int32.Parse(roomArr[roomArr.Length - 1]) - 1;

        //Debug.Log("player is in room idx:" + currPlayerRoomIdx);
        
    }

    private void OnPlayerEnter(Dictionary<string, object> message)
    {
        currPlayerRoomIdx = (int)message["roomIdx"];
        currPlayerRoom = (RoomSO)message["roomSO"];
        Debug.Log("player is in room idx:" + currPlayerRoomIdx);
    }

    private void OnAskRoomPosList(Dictionary<string, object> message)
    {
        EventManager.TriggerEvent("GetRoomPosList", new Dictionary<string, object> { { "roomPosList", currLevelSO.roomPos }});
    }

    private void OnEndScene(Dictionary<string, object> message)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnLastHit(Dictionary<string, object> message)
    {
        lastHitStr = (string)message["str"];
    }
}
