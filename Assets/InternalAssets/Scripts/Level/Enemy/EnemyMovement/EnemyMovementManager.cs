using UnityEngine;

[RequireComponent(typeof(EnemyMovementView), typeof(Bootstrap))]
public class EnemyMovementManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("Distance threshold to the next waypoint")]
    private float _distanceThreshold = 0.0f;
    [SerializeField, Tooltip("Enemy sprite prefab element")]
    private GameObject _enemySpritePrefab;

    private EnemyMovementModel _model;
    private EnemyMovementView _view;
    private EnemyMovementPresenter _presenter;

    public EnemyMovementPresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new EnemyMovementModel();

        ModelInit();

        _view = GetComponent<EnemyMovementView>();
        _presenter = new EnemyMovementPresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Lifecycle = GetComponent<EnemyLifecycleManager>().Presenter;
        _model.DistanceThreshold = _distanceThreshold;
        _model.EnemySpritePrefab = _enemySpritePrefab;
    }
}