using UnityEngine;

[RequireComponent(typeof(PlacementView), typeof(Bootstrap))]
public class PlacementManager : MonoBehaviour, IBootstrapable
{
    private PlacementModel _model;
    private PlacementView _view;
    private PlacementPresenter _presenter;

    public PlacementPresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new PlacementModel();

        ModelInit();

        _view = GetComponent<PlacementView>();
        _presenter = new PlacementPresenter(_model, _view);
    }

    private void ModelInit()
    {
        // Manager model initialization here
    }

    // Manager logic here
}