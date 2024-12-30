using UnityEngine;

[RequireComponent(typeof(EnemyLifecycleView), typeof(Bootstrap))]
public class EnemyLifecycleManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("Enemy stats")]
    private EnemyStats _enemyStats;

    private EnemyLifecycleModel _model;
    private EnemyLifecycleView _view;
    private EnemyLifecyclePresenter _presenter;

    public EnemyLifecyclePresenter Presenter => _presenter;
    public EnemyStats Stats => _enemyStats;

    public void BootstrapInit()
    {
        _model = new EnemyLifecycleModel();

        ModelInit();

        _view = GetComponent<EnemyLifecycleView>();
        _presenter = new EnemyLifecyclePresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Stats = _enemyStats;
        _model.HitPoints = _enemyStats.HitPoints;
    }
}