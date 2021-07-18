using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy": { GetAttacked(collision.gameObject); break; }
            default: { break; }
        }
    }

    private void GetAttacked(GameObject obj)
    {
        float val = obj.GetComponent<Enemy>().getAttack();
        GetComponent<Player>().decreaseHP(val);
    }
}
