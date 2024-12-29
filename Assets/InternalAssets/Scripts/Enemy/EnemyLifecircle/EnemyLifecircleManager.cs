using UnityEngine;

[RequireComponent(typeof(EnemyLifecircleView), typeof(Bootstrap))]
public class EnemyLifecircleManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("Enemy stats")]
    private EnemyStats _enemyStats;

    private EnemyLifecircleModel _model;
    private EnemyLifecircleView _view;
    private EnemyLifecirclePresenter _presenter;

    public EnemyLifecirclePresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new EnemyLifecircleModel();
        _view = GetComponent<EnemyLifecircleView>();
        _presenter = new EnemyLifecirclePresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Stats = _enemyStats;
        _model.HitPoints = _enemyStats.HitPoints;
    }
}