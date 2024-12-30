using System;
using UnityEngine;

public class StageLifecycleView : MonoBehaviour
{
    public Action OnStart;

    private void Start()
    {
        OnStart?.Invoke();
    }
}