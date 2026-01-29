public class PoisonBuff : Buff
{
  private float damagePerSecond;
  private float damageAccumulator;

  public PoisonBuff(float dps, float duration)
  {
    Name = "Poison";
    damagePerSecond = dps;
    Duration = duration;
  }

  public override void OnUpdate(BattleEntity target, float dt)
  {
    base.OnUpdate(target, dt);

    damageAccumulator += damagePerSecond * dt;
    int damage = (int)damageAccumulator;

    if (damage > 0)
    {
      damageAccumulator -= damage;
      target.TakeDamage(damage, false);

      UnityEngine.Debug.Log($"{target.Name} takes {damage} poison damage");
    }
  }
}
