using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/Enemy", order = 4)]
public class EnemySO : ScriptableObject
{
    [SerializeField] internal string enemyTypeID;
    [SerializeField] internal float enemyHP;
    [SerializeField] internal float enemyAttack;
    [SerializeField] internal float enemyWalkSpeed;
    [SerializeField] internal float enemyAttackRange;
    [SerializeField] internal float enemyVisualRange;

    [SerializeField] internal Enemy.AttackType attackType;
    [SerializeField] internal Enemy.MovementType moveType;

    [SerializeField] internal Sprite sprite0;
    [SerializeField] internal Sprite sprite1;

    [SerializeField] internal string lastHitStr;
}
