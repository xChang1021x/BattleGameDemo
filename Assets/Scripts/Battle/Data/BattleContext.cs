using System.Collections.Generic;

public static class BattleContext
{
  public static BattleEntity Player { get; private set; }

  private static readonly List<BattleEntity> enemies
      = new List<BattleEntity>();

  public static IReadOnlyList<BattleEntity> Enemies => enemies;

  public static void SetPlayer(BattleEntity player)
  {
    Player = player;
  }

  public static void AddEnemy(BattleEntity enemy)
  {
    enemies.Add(enemy);
  }

  public static void RemoveEnemy(BattleEntity enemy)
  {
    enemies.Remove(enemy);
  }

  public static void Clear()
  {
    Player = null;
    enemies.Clear();
  }
}
