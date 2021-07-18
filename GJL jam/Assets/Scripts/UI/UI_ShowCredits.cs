using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShowCredits : MonoBehaviour
{
    [SerializeField] internal Button okBtn;
    [SerializeField] internal Image bg;

    private void Awake()
    {
        okBtn.onClick.AddListener(OkBtnClicked);
        okBtn.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.StartListening("ShowCredits", OnShowCredits);
    }

    private void OnDisable()
    {
        EventManager.StopListening("ShowCredits", OnShowCredits);
    }

    private void OkBtnClicked()
    {
        okBtn.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
    }

    private void OnShowCredits(Dictionary<string, object> message)
    {
        //Debug.Log("show creditsss");
        okBtn.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);

    }
}
