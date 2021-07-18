using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAnimate : MonoBehaviour
{
    internal Enemy enemy;
    private Sprite sprite0;
    private Sprite sprite1;
    private bool sprite0Active = true;

    private float frameRate = 0.5f;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        sprite0 = enemy.so.sprite0;
        sprite1 = enemy.so.sprite1;
    }

    private void Start()
    {
        InvokeRepeating("AnimateSprite", frameRate, frameRate);
    }

    private void AnimateSprite()
    {
        if (sprite0Active)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else
        {
            enemy.GetComponent<SpriteRenderer>().sprite = sprite0;
        }

        sprite0Active = !sprite0Active;
    }

}
