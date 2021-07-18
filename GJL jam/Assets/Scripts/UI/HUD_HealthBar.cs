using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_HealthBar : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("SetHUDHP", SetHUDHealth);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SetHUDHP", SetHUDHealth);
    }

    private void SetHUDHealth(Dictionary<string, object> message)
    {
        GetComponent<Slider>().value = (float)message["hp"];
    }
}
