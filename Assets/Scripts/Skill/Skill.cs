public abstract class Skill
{
  public int Id { get; }
  public string Name { get; }
  public float Cooldown { get; }

  protected Skill(int id, string name, float cooldown)
  {
    Id = id;
    Name = name;
    Cooldown = cooldown;
  }

  public void Cast(BattleEntity caster, BattleEntity target)
  {
    OnCast(caster, target);
  }

  protected abstract void OnCast(
      BattleEntity caster,
      BattleEntity target);
}
