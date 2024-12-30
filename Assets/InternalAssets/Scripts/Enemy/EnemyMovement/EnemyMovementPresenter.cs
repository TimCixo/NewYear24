using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementPresenter
{
    private EnemyMovementModel _model;
    private EnemyMovementView _view;

    public List<Transform> Points { set {_model.Points = value;}}
    public Transform EndPoint { set {_model.EndPoint = value;}}

    public EnemyMovementPresenter(EnemyMovementModel model, EnemyMovementView view)
    {
        _model = model;
        _view = view;

        _view.OnFixedUpdate += OnFixedUpdate;
    }

    private void OnFixedUpdate()
    {
        float distance = Vector3.Distance(_view.transform.position, _model.Point.transform.position);

        if (distance < _model.DistanceThreshold)
        {
            NextPoint();
        }

        Move();
    }

    private void Move()
    {
        _view.transform.position = Vector3.MoveTowards(_view.transform.position, _model.Point.transform.position, _model.Presenter.MovementSpeed * Time.fixedDeltaTime);
    }

    private void NextPoint()
    {
        if (_model.I < _model.Points.Count)
        {
            _model.Point = _model.Points[_model.I++];
            
        }
        else
        {
            _model.Point = _model.EndPoint;
        }

        return;
    }
}