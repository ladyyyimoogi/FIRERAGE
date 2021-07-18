using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    [SerializeField] internal string lastHitStr;   
    public void TriggerDeath()
    {
        // UI: you killed the hostage
        //UI: game over
        Debug.Log("you killed the hostage");
        EventManager.TriggerEvent("LastHit", new Dictionary<string, object> { { "str", lastHitStr } });
        EventManager.TriggerEvent("ShowGameOver", new Dictionary<string, object> { { "x", 0 } });
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.gameover } });
        this.gameObject.SetActive(false);
    }
}
