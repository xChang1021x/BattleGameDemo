public class NormalAttack : Skill
{
  public NormalAttack(int id, string name, float cooldown) : base(id, name, cooldown)
  {

  }

  protected override void OnCast(BattleEntity caster, BattleEntity target)
  {
    UnityEngine.Debug.Log("Normal Attack");
    DamageContext ctx = new DamageContext
    {
      Attacker = caster,
      Defender = target,
    };

    int damage = DamageCalculator.Calculate(ctx);
    target.TakeDamage(damage, ctx.IsCritical);

    UnityEngine.Debug.Log($"[{caster.Name}] attacks [{target.Name}] for {damage} damage");
    UnityEngine.Debug.Log(ctx.IsCritical ? "Critical hit!" : "Not a critical hit.");
    UnityEngine.Debug.Log($"{target.Name} has {target.HP} HP left");
  }
}