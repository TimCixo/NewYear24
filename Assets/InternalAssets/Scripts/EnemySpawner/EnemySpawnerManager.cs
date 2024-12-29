using System.IO;
using UnityEngine;

[RequireComponent(typeof(EnemySpawnerView), typeof(Bootstrap))]
public class EnemySpawnerManager : MonoBehaviour, IBootstrapable
{
    [SerializeField]
    private PathManager _pathManager;

    private EnemySpawnerModel _model;
    private EnemySpawnerView _view;
    private EnemySpawnerPresenter _presenter;

    public EnemySpawnerPresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new EnemySpawnerModel();
        _view = GetComponent<EnemySpawnerView>();
        _presenter = new EnemySpawnerPresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Path = _pathManager.Presenter;
    }
}