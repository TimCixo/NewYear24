using UnityEngine;

[RequireComponent(typeof(UnitUpgradeView), typeof(Bootstrap))]
public class UnitUpgradeManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("Unit upgrade info")]
    private UnitStats _unitStats;

    private UnitUpgradeModel _model;
    private UnitUpgradeView _view;
    private UnitUpgradePresenter _presenter;

    public UnitUpgradePresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new UnitUpgradeModel();

        ModelInit();

        _view = GetComponent<UnitUpgradeView>();
        _presenter = new UnitUpgradePresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.Stats = _unitStats;
        _model.Attack = GetComponent<UnitAttackManager>().Presenter;
    }
}