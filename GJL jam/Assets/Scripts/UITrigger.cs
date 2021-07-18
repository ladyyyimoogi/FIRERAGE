using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    [SerializeField] internal string messageTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EventManager.TriggerEvent("SetTimedTextUI", new Dictionary<string, object> { { "msg", messageTrigger } });
        }
    }
}
