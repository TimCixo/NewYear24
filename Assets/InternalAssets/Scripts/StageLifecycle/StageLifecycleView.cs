using System;
using TMPro;
using UnityEngine;

public class StageLifecycleView : MonoBehaviour
{
    [SerializeField, Tooltip("Text component to display current stage number")]
    private TextMeshProUGUI _stageNumber;

    public event Action OnStart;

    private void Start()
    {
        OnStart?.Invoke();
    }

    public void SetStageNumber(int stageNumber)
    {
        _stageNumber.text = $"Stage: {stageNumber.ToString("00")}";
    }
}