using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerAnimate))]


public class Player : MonoBehaviour
{
    internal SpriteRenderer sr;
    internal Collider2D col;

    [SerializeField] internal Sprite player_noWeapon_0;
    [SerializeField] internal Sprite player_noWeapon_1;
    [SerializeField] internal Sprite player_0;
    [SerializeField] internal Sprite player_1;

    [SerializeField] internal bool isWithWeapon = true;

    internal float walkSpeed = 5f;
    internal float playerHP = 10f;

    internal bool flamethLaunched = false;
    internal bool hasKey = false;
    [SerializeField] internal ParticleSystem flame;
    [SerializeField]internal GameObject childObj_flame;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        
    }

    private void Start()
    {
        childObj_flame.SetActive(false);
        flame.Stop();

        //EventManager.TriggerEvent("SetHUDOil", new Dictionary<string, object> { { "val", false } });
        EventManager.TriggerEvent("SetHUDKey", new Dictionary<string, object> { { "val", false } });
        EventManager.TriggerEvent("SetHUDHP", new Dictionary<string, object> { { "hp", playerHP } });

    }

    internal bool checkWithWeapon()
    {
        return isWithWeapon;
    }

    internal void setWithWeapon(bool val)
    {
        isWithWeapon = val;
        if(isWithWeapon == true && flamethLaunched == false)
        {
            EventManager.TriggerEvent("SetHUDOil", new Dictionary<string, object> { { "val", true } });
        }
        ChangeSprite(val);
    }

    internal void ChangeSprite(bool val)
    {
        GetComponent<PlayerAnimate>().CancelInvoke("AnimateSprite");
        GetComponent<PlayerAnimate>().SetSprite();
        
    }

    internal bool checkCanShoot()
    {
        if(isWithWeapon && flamethLaunched == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal bool checkIfFlamethLaunched()
    {
        return flamethLaunched;
    }

    internal void setFlamethLaunched(bool val)
    {
        flamethLaunched = val;
        EventManager.TriggerEvent("SetHUDOil", new Dictionary<string, object> { { "val", !flamethLaunched } });
    }

    internal void increaseHP(float val)
    {
        playerHP += val;
        EventManager.TriggerEvent("SetHUDHP", new Dictionary<string, object> { { "hp", playerHP } });
    }

    internal void decreaseHP(float val)
    {
        playerHP -= val;
        EventManager.TriggerEvent("SetHUDHP", new Dictionary<string, object> { { "hp", playerHP} });
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if(playerHP <= 0)
        {
            //YOU'RE DEAD
            this.gameObject.SetActive(false);
            EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.dead } });
            EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.gameover } });
            EventManager.TriggerEvent("ShowGameOver", new Dictionary<string, object> { { "x", 0 } });
            
        }
    }

    internal bool checkHasKey()
    {
        return hasKey;
    }

    internal void setHasKey(bool val)
    {
        hasKey = val;
    }
    
}

