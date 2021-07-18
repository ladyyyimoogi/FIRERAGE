using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrigger : MonoBehaviour
{
    [SerializeField] internal GameObject parentCageObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bool val = collision.gameObject.GetComponent<Player>().checkHasKey();
            parentCageObj.GetComponent<Cage>().SetCanOpenCage(val);
        }
    }
}
