using System;
using UnityEngine;

public class UnitAttackView : MonoBehaviour
{
    public event Action OnFixedUpdate;

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}