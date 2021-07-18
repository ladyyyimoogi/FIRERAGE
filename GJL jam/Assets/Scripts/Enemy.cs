using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    internal enum AttackType
    {
        Melee,
        Range
    }
    internal enum MovementType
    {
        CanMove,
        DontMove
    }

    [SerializeField] internal GameObject managerObj;

    [SerializeField] internal EnemySO so;
    [SerializeField] internal RoomSO currRoom;
    
    private float enemyHP = 0f;
    private float enemyAttack = 0f;
    //private float enemyWalkSpeed;
    //private float enemyAttackRange;
    //private float enemyVisualRange;

    //private Enemy.AttackType attackType;
    //private Enemy.MovementType moveType;

    private void Awake()
    {
        InitEnemy();
    }

    private void InitEnemy()
    {
        enemyHP = so.enemyHP;
        enemyAttack = so.enemyAttack;
        //enemyWalkSpeed = so.enemyWalkSpeed;
        //enemyAttackRange = so.enemyAttackRange;
        //enemyVisualRange = so.enemyVisualRange;
        //attackType = so.attackType;
        //moveType = so.moveType;
    }

    internal void DecreaseHP(float val)
    {
        enemyHP -= val;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if(enemyHP <= 0)
        {
            //dead
            EventManager.TriggerEvent("SetHUDScore", new Dictionary<string, object> { { "score", 10 } });
            EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.dead } });
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }

    internal float getAttack()
    {
        EventManager.TriggerEvent("LastHit", new Dictionary<string, object> { { "str", so.lastHitStr } });
        return enemyAttack;
    }

    private void OnEnable()
    {
        EventManager.StartListening("EnemyEnter", SetCurrRoom);
    }

    private void OnDisable()
    {
        EventManager.StopListening("EnemyEnter", SetCurrRoom);
    }

    private void SetCurrRoom(Dictionary<string, object> message)
    {
        currRoom = (RoomSO)message["roomSO"];
    }

    internal float GetHP()
    {
        return enemyHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BombProj")
        {
            this.enemyHP = 0;
            CheckIfDead();
        }
    }
}
