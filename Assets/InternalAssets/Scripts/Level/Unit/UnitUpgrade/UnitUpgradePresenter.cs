public class UnitUpgradePresenter
{
    private UnitUpgradeModel _model;
    private UnitUpgradeView _view;

    public UnitUpgradePresenter(UnitUpgradeModel model, UnitUpgradeView view)
    {
        _model = model;
        _view = view;
    }

    public void Upgrade()
    {
        _model.Attack.AttackDamage *= _model.Stats.AttackDamageCoefficient;
        _model.Attack.AttackModifier *= _model.Stats.AttackModifierCoefficient;

        _model.Level++;
    }
}