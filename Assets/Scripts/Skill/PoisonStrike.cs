using System.Diagnostics;

public class PoisonStrike : Skill
{
  private int buffId;
  private float damageRate;

  public PoisonStrike(
      int id,
      string name,
      float cooldown,
      int buffId,
      float damageRate)
      : base(id, name, cooldown)
  {
    this.buffId = buffId;
    this.damageRate = damageRate;
  }

  protected override void OnCast(
      BattleEntity caster,
      BattleEntity target)
  {
    UnityEngine.Debug.Log("Poison Strike casted");
    DamageContext ctx = new DamageContext
    {
      Attacker = caster,
      Defender = target,
      DamageRate = damageRate
    };

    int damage = DamageCalculator.Calculate(ctx);
    target.TakeDamage(damage, ctx.IsCritical);

    var buffCfg = ConfigManager.BuffConfigs[buffId];
    Buff buff = BuffFactory.Create(buffCfg);
    target.Buffs.AddBuff(new BuffInstance(buff, buffCfg), target);
  }
}
