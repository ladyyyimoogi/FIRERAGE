using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_PlayBtn : MonoBehaviour
{
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlayBtnClicked);
    }

    private void PlayBtnClicked()
    {
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
        PlayerPrefs.SetInt("lastScore", 0);
        SceneManager.LoadScene(1);
        
    }
}
