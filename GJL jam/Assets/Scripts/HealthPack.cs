using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private float bonusHP = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Feeling more alive. . . " } });
            EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
            collision.gameObject.GetComponent<Player>().increaseHP(bonusHP);
            this.gameObject.SetActive(false);
        }
    }
}
