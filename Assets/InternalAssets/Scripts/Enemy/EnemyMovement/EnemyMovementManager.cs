using UnityEngine;

[RequireComponent(typeof(EnemyMovementView), typeof(Bootstrap))]
public class EnemyMovementManager : MonoBehaviour, IBootstrapable
{
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
        // Manager model initialization here
    }

    // Manager logic here
}