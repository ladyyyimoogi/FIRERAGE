using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [SerializeField] internal bool isFaceLeft = true;
    private Vector3 objScaleVector = new Vector3();
    private Vector3 rotationVector = new Vector3();

    private void OnEnable()
    {
        EventManager.StartListening("PlayerPosition", OnGetPlayerPosition);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlayerPosition", OnGetPlayerPosition);
    }

    private void OnGetPlayerPosition(Dictionary<string, object> message)
    {
        Vector2 playerPos = (Vector2)message["position"];
        if(this.gameObject.transform.position.x < playerPos.x && isFaceLeft == true)
        {
            ChangeFace();
        } 
        else if(this.gameObject.transform.position.x > playerPos.x && isFaceLeft == false)
        {
            ChangeFace();
        }
    }

    private void ChangeFace()
    {
        isFaceLeft = !isFaceLeft;
        objScaleVector = this.gameObject.transform.localScale;
        objScaleVector.x *= -1;
        this.gameObject.transform.localScale = objScaleVector;
        rotationVector = this.gameObject.transform.rotation.eulerAngles;
        rotationVector.y *= -1;
        this.gameObject.transform.rotation = Quaternion.Euler(rotationVector);
    }
}
