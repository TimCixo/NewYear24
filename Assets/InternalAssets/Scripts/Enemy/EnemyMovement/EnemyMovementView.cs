using System;
using UnityEngine;

public class EnemyMovementView : MonoBehaviour
{
    public event Action OnFixedUpdate;

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}