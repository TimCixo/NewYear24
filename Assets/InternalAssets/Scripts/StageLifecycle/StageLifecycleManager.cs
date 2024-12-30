using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StageLifecycleView), typeof(Bootstrap))]
public class StageLifecycleManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("List of stages")]
    private List<StageInfo> _stages = new List<StageInfo>();
    [SerializeField, Tooltip("Enemy spawner")]
    private EnemySpawnerManager _enemySpawnerManager;
    [SerializeField, Tooltip("Interval between enemy waves in seconds")]
    private float _interval = 0.0f;

    private StageLifecycleModel _model;
    private StageLifecycleView _view;
    private StageLifecyclePresenter _presenter;

    public StageLifecyclePresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new StageLifecycleModel();

        ModelInit();

        _view = GetComponent<StageLifecycleView>();
        _presenter = new StageLifecyclePresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Stages = _stages;
        _model.EnemySpawner = _enemySpawnerManager.Presenter;
        _model.Interval = _interval;
    }
}