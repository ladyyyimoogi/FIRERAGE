using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimedText : MonoBehaviour
{
    [SerializeField] internal Image childImage;
    [SerializeField] internal Text childText;
    private float timeShow = 2f;
    private bool isShow = false;

    private List<string> queuedMessage = new List<string>();

    private void OnEnable()
    {
        EventManager.StartListening("SetTimedTextUI", AddQueueMessage);
    }
    private void OnDisable()
    {
        EventManager.StopListening("SetTimedTextUI", AddQueueMessage);
    }

    private void AddQueueMessage(Dictionary<string, object> message)
    {
        queuedMessage.Add((string)message["msg"]);
    }

    private void Awake()
    {
        childImage.gameObject.SetActive(false);
        childText.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(isShow == false && queuedMessage.Count > 0)
        {
            isShow = true;
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        childText.text = queuedMessage[0];
        queuedMessage.RemoveAt(0);

        childImage.gameObject.SetActive(true);
        childText.gameObject.SetActive(true);

        Invoke("HideMessage", timeShow);
    }
    
    private void HideMessage()
    {
        childImage.gameObject.SetActive(false);
        childText.gameObject.SetActive(false);

        isShow = false;
    }
}
