using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ResetLevel : MonoBehaviour
{
    [SerializeField] internal Image childBG;
    [SerializeField] internal Button childYes;
    [SerializeField] internal Button childNo;

    private void Awake()
    {
        childBG.gameObject.SetActive(false);
        childYes.gameObject.SetActive(false);
        childNo.gameObject.SetActive(false);

        childYes.onClick.AddListener(BtnYesClicked);
        childNo.onClick.AddListener(BtnNoClicked);
    }

    private void OnEnable()
    {
        EventManager.StartListening("LaunchResetLevel", ShowMenu);

    }

    private void OnDisable()
    {
        EventManager.StopListening("LaunchResetLevel", ShowMenu);
    }

    private void ShowMenu(Dictionary<string,object> message)
    {
        childBG.gameObject.SetActive(true);
        childYes.gameObject.SetActive(true);
        childNo.gameObject.SetActive(true);
    }

    private void BtnYesClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
        if (PlayerPrefs.GetInt("bestScore") < PlayerPrefs.GetInt("lastScore"))
        {
            PlayerPrefs.SetInt("bestScore", PlayerPrefs.GetInt("lastScore"));
        }
        PlayerPrefs.SetInt("lastScore", 0);
    }

    private void BtnNoClicked()
    {
        childBG.gameObject.SetActive(false);
        childYes.gameObject.SetActive(false);
        childNo.gameObject.SetActive(false);
        EventManager.TriggerEvent("PlaySound", new Dictionary<string, object> { { "sfx", SoundManager.SoundPlay.collect } });
    }


}
