using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Score : MonoBehaviour
{
    private int score = 0;
    private bool stopCount = false;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("lastScore", 0);
        GetComponent<Text>().text = ConvertNumToString(score);
    }

    private void OnEnable()
    {
        EventManager.StartListening("SetHUDScore", SetHUDScore);
        EventManager.StartListening("StopCountScore", OnStopCount);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SetHUDScore", SetHUDScore);
        EventManager.StopListening("StopCountScore", OnStopCount);
    }

    private void SetHUDScore(Dictionary<string, object> message)
    {
        if(stopCount == false)
        {
            score += (int)message["score"];
            string val = ConvertNumToString(score);
            GetComponent<Text>().text = val;
            PlayerPrefs.SetInt("lastScore", score);
        }
        
    }

    private void OnStopCount(Dictionary<string, object> message)
    {
        stopCount = (bool)message["val"];
    }

    private string ConvertNumToString(int val)
    {
        string tmp = val.ToString();
        string str = "+";
        for (int i = 0; i < 11 - tmp.Length; i++)
        {
            str += "0";
        }
        str += tmp;
        return str;

    }
}
