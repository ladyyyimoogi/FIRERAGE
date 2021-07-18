using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] internal GameObject followObj;
    internal Transform followTransform;

    private void Awake()
    {
        followTransform = followObj.transform;
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector2(followTransform.position.x, followTransform.position.y);
    }
}
