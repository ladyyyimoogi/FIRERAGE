using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    [SerializeField] internal Image title;
    [SerializeField] internal Image textBg;
    [SerializeField] internal Text text;
    [SerializeField] internal Button btnTry;
    [SerializeField] internal Button btnBye;

    private string lastHitStr = "";

    private void Awake()
    {
        title.gameObject.SetActive(false);
        textBg.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        btnTry.gameObject.SetActive(false);
        btnBye.gameObject.SetActive(false);

        btnTry.onClick.AddListener(BtnTryClicked);
        btnBye.onClick.AddListener(BtnByeClicked);
    }

    private void OnEnable()
    {
        EventManager.StartListening("ShowGameOver", OnShowGameOver);
        EventManager.StartListening("LastHit", OnLastHit);
    }

    private void OnDisable()
    {
        EventManager.StopListening("ShowGameOver", OnShowGameOver);
        EventManager.StopListening("LastHit", OnLastHit);
    }

    private void OnShowGameOver(Dictionary<string, object> message)
    {
        if(PlayerPrefs.GetInt("bestScore") < PlayerPrefs.GetInt("lastScore"))
        {
            PlayerPrefs.SetInt("bestScore", PlayerPrefs.GetInt("lastScore"));
        }
        PlayerPrefs.SetInt("lastScore", 0);
        EventManager.TriggerEvent("StopCountScore", new Dictionary<string, object> { { "val", true } });
        Invoke("ShowGameOver", 0.2f);
    }

    private void OnLastHit(Dictionary<string, object> message)
    {
        lastHitStr = (string)message["str"];
    }

    private void ShowGameOver()
    {
        title.gameObject.SetActive(true);
        textBg.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        btnTry.gameObject.SetActive(true);
        btnBye.gameObject.SetActive(true);

        text.text = lastHitStr;
    }

    private void BtnTryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
    }

    private void BtnByeClicked()
    {
        // to main menu
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
        SceneManager.LoadScene(0);
    }
}
