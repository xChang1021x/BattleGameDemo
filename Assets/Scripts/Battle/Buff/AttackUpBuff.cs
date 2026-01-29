public class AttackUpBuff : Buff
{
  private int bonusAttack;

  public AttackUpBuff(int bonus, float duration)
  {
    Name = "Attack Up";
    Duration = duration;
    bonusAttack = bonus;
  }

  public override void OnAdd(BattleEntity target)
  {
    target.ATK.AddModifier(bonusAttack, 0f);
  }

  public override void OnRemove(BattleEntity target)
  {
    target.ATK.RemoveModifier(bonusAttack, 0f);
  }
}