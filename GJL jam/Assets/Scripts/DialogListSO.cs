using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/DialogList", order = 6)]
public class DialogListSO : ScriptableObject
{
    [SerializeField] internal bool nextLevel;

    [SerializeField] internal List<DialogSO> dialogArr;
}
