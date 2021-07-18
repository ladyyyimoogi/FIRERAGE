using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CreditsBtn : MonoBehaviour
{
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowCredits);
    }

    private void ShowCredits()
    {
        //Debug.Log("testBtn");
        EventManager.TriggerEvent("ShowCredits", new Dictionary<string, object> { { "val", 0 } });
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
    }
}
