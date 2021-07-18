using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    internal Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            CheckIfCanShoot();
        }
    }

    private void CheckIfCanShoot()
    {
        if (player.checkCanShoot())
        {
            Debug.Log("can shoot");
            Shoot();
        }
        else if(player.checkWithWeapon() == false)
        {
            //show message player doesnt have weapon
            EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "You can't use imagination to attack, y'know" } });
        }
        else if(player.checkWithWeapon() == true && player.checkIfFlamethLaunched() == true)
        {
            //show message there's no fuel for flamethrower
            EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Nope! Empty tank can't shoot fire" } });
        }
    }
    private void Shoot()
    {
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.flamethrower } });
        player.childObj_flame.SetActive(true);
        //ParticleSystem flameFX = Instantiate(player.flame);
        //flameFX.transform.parent = player.childObj_flame.transform;
        player.flame.Play();
        player.setFlamethLaunched(true);
    }
}
