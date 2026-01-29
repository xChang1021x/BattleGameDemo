public class BuffInstance
{
  public Buff Buff { get; }
  public BuffConfig Config { get; }

  public float RemainingTime { get; private set; }

  public bool IsExpired => RemainingTime <= 0f;

  public BuffInstance(Buff buff, BuffConfig config)
  {
    Buff = buff;
    Config = config;
    RemainingTime = config.Duration;
  }

  public void Tick(float deltaTime)
  {
    RemainingTime -= deltaTime;
  }
}
