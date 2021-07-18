using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Player))]
public class PlayerMove : MonoBehaviour
{
    internal Player player;

    internal bool moveLeft = false;
    internal bool moveRight = false;
    internal bool moveUp = false;
    internal bool moveDown = false;
    internal bool idle = true;

    private void Awake()
    {
        player = GetComponent<Player>();

    }

    private void Start()
    {
        //InvokeRepeating("UpdatePlayerPosition", 1, 1);
    }

    private void Update()
    {
        EventManager.TriggerEvent("PlayerPosition", new Dictionary<string, object> { { "position", new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y) } });
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.I))
        {
            //move up
            moveUp = true;
            moveDown = false;
            idle = false;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.K))
        {
            //move down
            moveUp = false;
            moveDown = true;
            idle = false;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.J))
        {
            //move left
            moveLeft = true;
            moveRight = false;
            idle = false;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L))
        {
            //move right
            moveLeft = false;
            moveRight = true;
            idle = false;
        }
        else
        {
            moveUp = false;
            moveDown = false;
            moveLeft = false;
            moveRight = false;
            idle = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (moveUp)
        {
            player.transform.Translate(Vector2.up * Time.deltaTime * player.walkSpeed);
        }
        if (moveDown)
        {
            player.transform.Translate(Vector2.down * Time.deltaTime * player.walkSpeed);
        }
        if (moveLeft)
        {
            player.transform.Translate(Vector2.left * Time.deltaTime * player.walkSpeed);
        }
        if (moveRight)
        {
            player.transform.Translate(Vector2.right * Time.deltaTime * player.walkSpeed);
        }
    }

    private void UpdatePlayerPosition()
    {
        EventManager.TriggerEvent("PlayerPosition", new Dictionary<string, object> { { "position", new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y) } });
    }
}
