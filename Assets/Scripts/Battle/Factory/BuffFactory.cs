public static class BuffFactory
{
  public static Buff Create(BuffConfig cfg)
  {
    return cfg.Type switch
    {
      "Poison" => new PoisonBuff(cfg.Dps, cfg.Duration),
      "AttackUp" => new AttackUpBuff(cfg.Value, cfg.Duration),
      "AttackPercent" => new AttackPercentBuff(cfg.Value, cfg.Duration),
      _ => null
    };
  }
}
