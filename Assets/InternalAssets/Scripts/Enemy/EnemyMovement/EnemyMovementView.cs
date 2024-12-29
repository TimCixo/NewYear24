using System;
using UnityEngine;

public class EnemyMovementView : MonoBehaviour
{
    public Action OnFixedUpdate;

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}