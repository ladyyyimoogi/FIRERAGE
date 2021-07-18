using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleCollision : MonoBehaviour
{

    [SerializeField] internal float attackHP = 1f;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        switch (other.tag)
        {
            case "Hostage": { HitHostage(other); break; }
            case "Enemy": { HitEnemy(other); break; }
            case "CanExplode": { HitCanExplode(other); break; }
            default: { break; }
        }
    }


    private void HitHostage(GameObject obj)
    {
        obj.GetComponent<Hostage>().TriggerDeath();
    }

    private void HitEnemy(GameObject obj)
    {
        obj.GetComponent<Enemy>().DecreaseHP(attackHP);
    }
    
    private void HitCanExplode(GameObject obj)
    {
        Debug.Log("is Hit");
        obj.GetComponent<Bomb>().TriggerExplosion();
    }
}
