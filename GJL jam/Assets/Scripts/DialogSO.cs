using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/Dialog", order = 5)]
public class DialogSO : ScriptableObject
{
    [SerializeField] internal string nameTxt;
    [SerializeField] [TextArea] internal string textTxt;
    [SerializeField] internal Sprite sprite;
    [SerializeField] internal UI_DialogSys.DialogBy by;

}
