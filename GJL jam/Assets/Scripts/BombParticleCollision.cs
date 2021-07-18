using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BombParticleCollision : MonoBehaviour
{
    [SerializeField] internal float attackHP = 1000f;
    internal string lastHitStr = "Watch your steps, Mr.-I-think-I-am-explosion-proof";
    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        switch (other.tag)
        {
            case "Player": { HitPlayer(other); break; }
            case "Enemy": { HitEnemy(other); break; }
            case "CanExplode": { HitCanExplode(other); break; }
            default: { break; }
        }
    }


    private void HitPlayer(GameObject obj)
    {
        obj.GetComponent<Player>().decreaseHP(attackHP);
        EventManager.TriggerEvent("LastHit", new Dictionary<string, object> { { "str", lastHitStr } });
    }

    private void HitEnemy(GameObject obj)
    {
        obj.GetComponent<Enemy>().DecreaseHP(attackHP);
    }

    private void HitCanExplode(GameObject obj)
    {
        obj.GetComponent<Bomb>().TriggerExplosion();
    }
}
