using UnityEngine;

[RequireComponent(typeof(EnemyMovementView), typeof(Bootstrap))]
public class EnemyMovementManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("Distance threshold to the next waypoint")]
    private float _distanceThreshold = 0.0f;

    private EnemyMovementModel _model;
    private EnemyMovementView _view;
    private EnemyMovementPresenter _presenter;

    public EnemyMovementPresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new EnemyMovementModel();
        _view = GetComponent<EnemyMovementView>();
        _presenter = new EnemyMovementPresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Presenter = GetComponent<EnemyLifecycleManager>().Presenter;
        _model.DistanceThreshold = _distanceThreshold;
    }
}