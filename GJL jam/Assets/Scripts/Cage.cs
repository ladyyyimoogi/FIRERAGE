using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    private bool canOpenCage = false;
    private bool hasKey = false;
    [SerializeField] internal GameObject cage;
    [SerializeField] internal GameObject cageBase;
    [SerializeField] internal DialogListSO so;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.M))
        {
            if(canOpenCage == true)
            {
                //open ...
                cage.SetActive(false);
                cageBase.SetActive(false);
                EventManager.TriggerEvent("SetHUDKey", new Dictionary<string, object> { { "val", false } });
                EventManager.TriggerEvent("SetHUDScore", new Dictionary<string, object> { { "score", 10 } });
                //UI: you freed a hostage
                EventManager.TriggerEvent("SendDialog", new Dictionary<string, object> { { "listSO", so } });
                EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.opencage } });
            }
            else if(hasKey == false)
            {
                //UI: you need a key
                EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Of course you need a key for that" } });
            }
            else
            {
                EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", "Get closer to the cage! Your arms are too short" } });
            }
        }
    }

    internal void SetCanOpenCage(bool val)
    {
        canOpenCage = val;
    }

    private void OnEnable()
    {
        EventManager.StartListening("PlayerGetKey", SetHasKey);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlayerGetKey", SetHasKey);
    }

    private void SetHasKey(Dictionary<string, object> message)
    {
        hasKey = (bool)message["val"];
    }
}
