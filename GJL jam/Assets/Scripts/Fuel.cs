using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<Player>().flamethLaunched == true)
            {
                collision.gameObject.GetComponent<Player>().setFlamethLaunched(false);
                //UI: flame thrower is refilled
                EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Flamethrower refilled" } });
                EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
                this.gameObject.SetActive(false);
            }
            else
            {
                //UI: you don't need it yet
                EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "You don't need it yet" } });
            }
        }
    }
}
