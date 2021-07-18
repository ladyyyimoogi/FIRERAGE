using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Oil : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("SetHUDOil", SetHUDOil);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SetHUDOil", SetHUDOil);
    }

    private void SetHUDOil(Dictionary<string, object> message)
    {
        Color col = GetComponent<Image>().color;
        col.a = (bool)message["val"] == true ? 255 : 0;
        GetComponent<Image>().color = col;
    }
}
