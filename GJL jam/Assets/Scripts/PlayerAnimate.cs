using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimate : MonoBehaviour
{
    internal Player player;
    private bool isWithWeapon;
    private Sprite sprite0;
    private Sprite sprite1;
    private bool sprite0Active = true;

    private float frameRate = 0.5f;

    private void Awake()
    {
        player = GetComponent<Player>();
        isWithWeapon = player.checkWithWeapon();
    }

    private void Start()
    {
        SetSprite();
    }

    internal void SetSprite()
    {
        CancelInvoke("AnimateSprite");
        if (player.checkWithWeapon() == true)
        {
            sprite0 = player.player_0;
            sprite1 = player.player_1;
        }
        else
        {
            sprite0 = player.player_noWeapon_0;
            sprite1 = player.player_noWeapon_1;
        }
        player.sr.sprite = sprite0;
        sprite0Active = true;

        InvokeRepeating("AnimateSprite", 0, frameRate);
    }

    private void AnimateSprite()
    {
        if (sprite0Active)
        {
            player.sr.sprite = sprite1;
        }
        else
        {
            player.sr.sprite = sprite0;
        }

        sprite0Active = !sprite0Active;
    }
}
