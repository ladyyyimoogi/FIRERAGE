using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ReloadBtn : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ReloadBtnClicked);
    }

    private void ReloadBtnClicked()
    {
        EventManager.TriggerEvent("LaunchResetLevel", new Dictionary<string, object> { {"x", null } });
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
    }
}
