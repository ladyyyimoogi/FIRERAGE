using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogSys : MonoBehaviour
{
    [SerializeField] internal Image dialogBGtop;
    [SerializeField] internal Image dialogBGbot;
    [SerializeField] internal Image potraitTop;
    [SerializeField] internal Image potraitBot;
    [SerializeField] internal Text nameTop;
    [SerializeField] internal Text nameBot;
    [SerializeField] internal Text textTop;
    [SerializeField] internal Text textBot;

    private bool topActive = false;
    private bool botActive = false;

    private bool nextLevelAfterQueue = false;

    private List<DialogSO> queuedDialog = new List<DialogSO>();

    internal enum DialogBy { Top, Bot}
    

    private void Awake()
    {
        HideAllObj();
    }

    private void OnEnable()
    {
        EventManager.StartListening("SendDialog", ShowDialog);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SendDialog", ShowDialog);
    }

    private void ShowDialog(Dictionary<string, object> message)
    {
        queuedDialog.Clear();
        queuedDialog = new List<DialogSO>();
        DialogListSO so = (DialogListSO)message["listSO"];
        //queuedDialog = so.dialogArr;
        for(int i = 0; i < so.dialogArr.Count; i++)
        {
            queuedDialog.Add(so.dialogArr[i]);
        }
        nextLevelAfterQueue = so.nextLevel;
        NextQueue();
    }

    private void NextQueue()
    {
        DialogSO so = queuedDialog[0];
        Debug.Log(so.textTxt);
        Activate(so);
        queuedDialog.RemoveAt(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if(queuedDialog.Count > 0)
            {
                NextQueue();
            }
            else if(nextLevelAfterQueue == true)
            {
                Debug.Log("NEXT LEVEL");
                EventManager.TriggerEvent("EndScene", new Dictionary<string, object> { { "x", 0 } });
                HideAllObj();
            }
            else
            {
                HideAllObj();
            }
        }
    }

    private void HideAllObj()
    {
        dialogBGtop.gameObject.SetActive(false);
        dialogBGbot.gameObject.SetActive(false);
        potraitTop.gameObject.SetActive(false);
        potraitBot.gameObject.SetActive(false);
        nameTop.gameObject.SetActive(false);
        nameBot.gameObject.SetActive(false);
        textTop.gameObject.SetActive(false);
        textBot.gameObject.SetActive(false);

        topActive = false;
        botActive = false;
    }

    private void Activate(DialogSO so)
    {
        if(so.by == DialogBy.Top)
        {
            dialogBGtop.gameObject.SetActive(true);
            potraitTop.gameObject.SetActive(true);
            nameTop.gameObject.SetActive(true);
            textTop.gameObject.SetActive(true);

            potraitTop.sprite = so.sprite;
            nameTop.text = so.nameTxt;
            textTop.text = so.textTxt;

            topActive = true;
        }
        else if(so.by == DialogBy.Bot)
        {
            dialogBGbot.gameObject.SetActive(true);
            potraitBot.gameObject.SetActive(true);
            nameBot.gameObject.SetActive(true);
            textBot.gameObject.SetActive(true);

            potraitBot.sprite = so.sprite;
            nameBot.text = so.nameTxt;
            textBot.text = so.textTxt;

            botActive = true;
        }
    }
}
