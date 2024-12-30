using System;
using UnityEngine;

public class StageLifecycleView : MonoBehaviour
{
    public event Action OnStart;

    private void Start()
    {
        OnStart?.Invoke();
    }
}