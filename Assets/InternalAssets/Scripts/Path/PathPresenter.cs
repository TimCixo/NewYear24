using System.Collections.Generic;
using UnityEngine;

public class PathPresenter
{
    private PathModel _model;
    private PathView _view;

    public Transform StartPoint => _model.StartPoint;
    public Transform EndPoint => _model.EndPoint;
    public List<GameObject> Points => _model.Points;

    public PathPresenter(PathModel model, PathView view)
    {
        _model = model;
        _view = view;
    }
}
