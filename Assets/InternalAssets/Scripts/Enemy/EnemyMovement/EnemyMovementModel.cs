using UnityEngine;

public class EnemyMovementModel
{
    public int I = 0;
    public float DistanceThreshold = 0.0f;
    public Transform Point;
    public PathPresenter Path;
    public EnemyLifecyclePresenter Lifecycle;
    public GameObject EnemySpritePrefab;
}