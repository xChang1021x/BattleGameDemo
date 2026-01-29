public abstract class Buff
{
  public int Id;
  public string Name;
  public float Duration;
  protected float timer;

  public bool IsExpired => timer >= Duration;

  public virtual void OnAdd(BattleEntity target) { }
  public virtual void OnRemove(BattleEntity target) { }
  public virtual void OnUpdate(BattleEntity target, float deltaTime)
  {
    timer += deltaTime;
  }
}