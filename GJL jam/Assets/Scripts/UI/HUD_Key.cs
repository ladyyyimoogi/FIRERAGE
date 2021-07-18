using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Key : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("SetHUDKey", SetHUDKey);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SetHUDKey", SetHUDKey);
    }

    private void SetHUDKey(Dictionary<string, object> message)
    {
        Color col = GetComponent<Image>().color;
        col.a = (bool)message["val"] == true ? 255 : 0;
        GetComponent<Image>().color = col;
    }
}
