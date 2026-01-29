using System;

public static class SkillFactory
{
  public static Skill Create(SkillConfig config)
  {
    UnityEngine.Debug.Log($"Creating skill: {config.Name}");
    switch (config.SkillType)
    {
      case "NormalAttack":
        return new NormalAttack(
            config.id,
            config.Name,
            config.Cooldown
        );
      case "PoisonStrike":
        return new PoisonStrike(
            config.id,
            config.Name,
            config.Cooldown,
            config.BuffId,
            config.DamageRate
        );

      default:
        throw new Exception($"Unknown SkillType: {config.SkillType}");
    }
  }
}
