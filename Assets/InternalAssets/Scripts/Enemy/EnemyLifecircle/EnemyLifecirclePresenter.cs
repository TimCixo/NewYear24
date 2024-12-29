using UnityEngine;

public class EnemyLifecirclePresenter
{
    private EnemyLifecircleModel _model;
    private EnemyLifecircleView _view;

    public EnemyLifecirclePresenter(EnemyLifecircleModel model, EnemyLifecircleView view)
    {
        _model = model;
        _view = view;
    }

    // Presenter logic here
}