using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerDirection : MonoBehaviour
{
    internal Player player;

    internal bool faceLeft = false;

    internal Vector2 mousePos;
    internal Vector3 rotationVector;
    internal Vector2 playerScaleVector;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > player.transform.position.x && faceLeft == true)
        {
            ChangeFace();
        }
        else if (mousePos.x < player.transform.position.x && faceLeft == false)
        {
            ChangeFace();
        }
    }

    private void ChangeFace()
    {
        faceLeft = !faceLeft;
        playerScaleVector = player.transform.localScale;
        playerScaleVector.x *= -1;
        player.transform.localScale = playerScaleVector;
        rotationVector = player.transform.rotation.eulerAngles;
        rotationVector.y *= -1;
        player.transform.rotation = Quaternion.Euler(rotationVector);
    }
}
