using UnityEngine;

[RequireComponent(typeof(EnemySpawnerView), typeof(Bootstrap))]
public class EnemySpawnerManager : MonoBehaviour, IBootstrapable
{
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
        // Manager model initialization here
    }

    // Manager logic here
}