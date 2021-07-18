using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] internal ParticleSystem bombFX;
    [SerializeField] internal ParticleSystem bombbgFX;

    private void Awake()
    {
        bombFX.Stop();
        bombbgFX.Stop();
    }

    internal void TriggerExplosion()
    {
        Invoke("Explode", 0);
        Invoke("DeactiveBomb", 2);
        Debug.Log("Explosion triggered");
    }

    internal void Explode()
    {
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.explosion } });
        bombFX.Play();
        bombbgFX.Play();
    }

    internal void DeactiveBomb()
    {
        EventManager.TriggerEvent("SetHUDScore", new Dictionary<string, object> { { "score", 5 } });
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ProjPlayer" || collision.gameObject.tag == "BombProj")
        {
            TriggerExplosion();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ProjPlayer" || collision.gameObject.tag == "BombProj")
        {
            TriggerExplosion();
        }
    }
}
