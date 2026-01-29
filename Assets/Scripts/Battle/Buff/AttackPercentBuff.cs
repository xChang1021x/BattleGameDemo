public class AttackPercentBuff : Buff
{
  private float percent;

  public AttackPercentBuff(float value, float duration)
  {
    Name = "Attack Percent Buff";
    Duration = duration;
    percent = value;
  }

  public override void OnAdd(BattleEntity target)
  {
    target.ATK.AddModifier(0, percent);
  }

  public override void OnRemove(BattleEntity target)
  {
    target.ATK.RemoveModifier(0, percent);
  }
}