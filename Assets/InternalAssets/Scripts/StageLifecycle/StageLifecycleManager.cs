using UnityEngine;

[RequireComponent(typeof(StageLifecycleView), typeof(Bootstrap))]
public class StageLifecycleManager : MonoBehaviour, IBootstrapable
{
    private StageLifecycleModel _model;
    private StageLifecycleView _view;
    private StageLifecyclePresenter _presenter;

    public StageLifecyclePresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new StageLifecycleModel();
        _view = GetComponent<StageLifecycleView>();
        _presenter = new StageLifecyclePresenter(_model, _view);
    }

    private void ModelInit()
    {
        // Manager model initialization here
    }

    // Manager logic here
}