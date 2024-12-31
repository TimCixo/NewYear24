using UnityEngine;

public class EnemyMovementPresenter
{
    private EnemyMovementModel _model;
    private EnemyMovementView _view;

    public PathPresenter Path { set { _model.Path = value; } }

    public EnemyMovementPresenter(EnemyMovementModel model, EnemyMovementView view)
    {
        _model = model;
        _view = view;
    }

    public void Start()
    {
        _model.Point = _model.Path.Points[0].transform;

        _view.OnFixedUpdate += OnFixedUpdate;
    }

    private void OnFixedUpdate()
    {
        float distance = Vector3.Distance(_view.transform.position, _model.Point.transform.position);

        if (distance < _model.DistanceThreshold)
        {
            NextPoint();
        }

        Rotate();
        Move();
    }

    private void Rotate()
    {
        _view.transform.up = _model.Point.transform.position - _view.transform.position;
    }

    private void Move()
    {
        float movementSpeed = _model.Lifecycle.MovementSpeed * Time.fixedDeltaTime / 2f;

        _view.transform.position = Vector3.MoveTowards(_view.transform.position, _model.Point.transform.position, movementSpeed);
    }

    private void NextPoint()
    {
        if (_model.I < _model.Path.Points.Count)
        {
            _model.Point = _model.Path.Points[_model.I++].transform;

        }
        else
        {
            _model.Point = _model.Path.EndPoint;
        }
    }
}