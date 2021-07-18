using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOWeapon : MonoBehaviour
{
    [SerializeField] internal DialogListSO so;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EventManager.TriggerEvent("SendDialog", new Dictionary<string, object> { { "listSO", so } });
        }
    }
}
