public class UnitUpgradeModel
{
    public int Level = 1;
    public UnitStats Stats;
    public UnitAttackPresenter Attack;
    public float AttackDamageCoefficient => Stats.AttackDamageCoefficient;
    public float AttackModifierCoefficient => Stats.AttackModifierCoefficient;
}