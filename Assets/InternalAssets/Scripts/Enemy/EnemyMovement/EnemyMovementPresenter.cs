using UnityEngine;

public class EnemyMovementPresenter
{
    private EnemyMovementModel _model;
    private EnemyMovementView _view;

    public EnemyMovementPresenter(EnemyMovementModel model, EnemyMovementView view)
    {
        _model = model;
        _view = view;
    }

    // Presenter logic here
}