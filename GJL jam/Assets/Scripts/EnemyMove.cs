using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    private bool playerIsInRange = false;
    [SerializeField]private bool playerIsInSameRoom = false;
    private bool enemyIsMoving = false;

    private bool enemyNoticePlayer = false;
    private RoomSO playerRoom;
    [SerializeField]private RoomSO currRoom;
    private Enemy enemy;

    private float enemyMinimumDistanceToPlayer = 0f;
    private float enemyNoticeRange = 0f;

    private Vector2 playerPosition = new Vector2();

    
    private Vector2 goalPos = new Vector2();
    private List<RoomSO> goalPath = new List<RoomSO>();
    private List<Vector2> roomPos = new List<Vector2>();
    private List<Vector2> goalPosList = new List<Vector2>();

    private void Awake()
    {
        this.enemy = this.GetComponent<Enemy>();
        this.currRoom = this.enemy.currRoom;
        this.enemyMinimumDistanceToPlayer = this.enemy.so.enemyAttackRange - 1;
        this.enemyNoticeRange = this.enemy.so.enemyVisualRange;
    }

    private void OnEnable()
    {
        EventManager.StartListening("PlayerEnter", GetPlayerRoom);
        EventManager.StartListening("PlayerPosition", GetPlayerPosition);
        EventManager.StartListening("GetRoomPosList", OnGetRoomPosList);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlayerEnter", GetPlayerRoom);
        EventManager.StopListening("PlayerPosition", GetPlayerPosition);
        EventManager.StopListening("GetRoomPosList", OnGetRoomPosList);
    }

    private void GetPlayerRoom(Dictionary<string, object> message)
    {
        this.playerRoom = (RoomSO)message["roomSO"];
        CheckIfIsInSameRoomWithPlayer();
    }

    internal void SetCurrRoom(RoomSO room)
    {
        this.currRoom = room;
    }

    private void CheckIfIsInSameRoomWithPlayer()
    {
        this.playerIsInSameRoom = this.playerRoom == this.currRoom ? true : false;
        /*if(this.playerIsInSameRoom == false && enemy.GetHP() > 0f)
        {
            
            Pathfinder pathAI = new Pathfinder(currRoom, playerRoom);
            goalPath.Clear();
            goalPath = new List<RoomSO>();
            goalPath = pathAI.SearchPath();

            goalPosList.Clear();
            goalPosList = new List<Vector2>();

            for(int i = 0; i < goalPath.Count; i++)
            {
                goalPosList.Add(getPos(goalPath[i]));
            }
        }
        */
        if(this.enemyIsMoving == false && this.playerIsInSameRoom)
        {
            this.enemyIsMoving = true;
        }
        
    }

    private void GetPlayerPosition(Dictionary<string, object> message)
    {
        this.playerPosition = (Vector2)message["position"];
        Debug.Log(playerPosition);
    }

    private void OnGetRoomPosList(Dictionary<string, object> message)
    {
        roomPos = (List<Vector2>)message["roomPosList"];
    }

    private void Start()
    {
        EventManager.TriggerEvent("AskRoomPosList", new Dictionary<string, object> { { "x", null } });
    }
    private void Update()
    {
        /*if (this.playerRoom == this.currRoom)
        {
            //this.enemyIsMoving = true;
            this.goalPos = this.playerPosition;
        }
        else
        {
            //this.enemyIsMoving = false;
            //use goal
            if(goalPosList.Count > 0)
            {
                if (Vector2.Distance((Vector2)this.gameObject.transform.position, goalPosList[0]) < 0.5f)
                {
                    goalPosList.RemoveAt(0);
                }
                this.goalPos = goalPosList[0];
            }
            
        }*/

        this.goalPos = this.playerPosition;
            
    }

    private void FixedUpdate()
    {
        if (this.enemyIsMoving)
        {
            //this.gameObject.transform.Translate((Vector2)this.playerPosition * Time.deltaTime * this.enemy.so.enemyWalkSpeed * 0.5f);
            this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(this.goalPos.x, this.goalPos.y, this.transform.position.z), this.enemy.so.enemyWalkSpeed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyIgnore")
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.collider);
        }
    }

    private Vector2 getPos(RoomSO room)
    {
        string[] roomArr = room.name.Split('_');
        int roomIdx = Int32.Parse(roomArr[roomArr.Length - 1]) - 1;
        return roomPos[roomIdx];
    }

}
