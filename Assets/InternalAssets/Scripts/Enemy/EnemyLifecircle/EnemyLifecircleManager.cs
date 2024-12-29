using UnityEngine;

[RequireComponent(typeof(EnemyLifecircleView), typeof(Bootstrap))]
public class EnemyLifecircleManager : MonoBehaviour, IBootstrapable
{
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
        // Manager model initialization here
    }

    // Manager logic here
}