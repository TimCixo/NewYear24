using UnityEngine;

public class PlacementPresenter
{
    private PlacementModel _model;
    private PlacementView _view;

    public PlacementPresenter(PlacementModel model, PlacementView view)
    {
        _model = model;
        _view = view;
    }

    // Presenter logic here
}