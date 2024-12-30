using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementModel
{
    public uint I = 0;
    public float DistanceThreshold = 0.0f;
    public Transform Point;
    public Transform EndPoint;
    public EnemyLifecyclePresenter Presenter;
    public List<Transform> Points;
}