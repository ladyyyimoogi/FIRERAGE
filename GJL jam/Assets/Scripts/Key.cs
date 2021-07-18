using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().setHasKey(true);
            this.gameObject.SetActive(false);
            EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "This is going to be useful later" } });
            EventManager.TriggerEvent("SetHUDKey", new Dictionary<string, object> { { "val", true } });
            EventManager.TriggerEvent("PlayerGetKey", new Dictionary<string, object> { { "val", true } });
            EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
            //Debug.Log("you got the key");
            //UI: you get the key
        }
    }
}
