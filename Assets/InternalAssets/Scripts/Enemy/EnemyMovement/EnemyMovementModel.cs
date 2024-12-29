using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementModel
{
    public uint I = 0;
    public float DistanceThreshold = 0.0f;
    public GameObject Point;
    public List<GameObject> Points;
    public EnemyLifecirclePresenter Presenter;
}