public class SkillInstance
{
  public Skill Skill { get; }
  public SkillConfig Config { get; }

  public float RemainingCD { get; private set; }

  public bool IsReady => RemainingCD <= 0f;

  public SkillInstance(Skill skill, SkillConfig config)
  {
    Skill = skill;
    Config = config;
    RemainingCD = 0f;
  }

  public bool TryCast(BattleEntity caster, BattleEntity target)
  {
    if (!IsReady)
      return false;

    Skill.Cast(caster, target);
    RemainingCD = Skill.Cooldown;
    return true;
  }

  public void Tick(float deltaTime)
  {
    if (RemainingCD > 0f)
      RemainingCD -= deltaTime;
  }
}
