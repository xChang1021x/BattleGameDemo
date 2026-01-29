using UnityEngine;

public static class PlayerTargetingSystem
{
  public static BattleEntity FindClosestEnemy(
      BattleEntity player,
      float range)
  {
    BattleEntity closest = null;
    float minDist = float.MaxValue;

    foreach (BattleEntity enemy in BattleContext.Enemies)
    {
      if (enemy.IsDead) continue;

      float dist = Vector3.Distance(
          player.View.transform.position,
          enemy.View.transform.position
      );

      if (dist <= range && dist < minDist)
      {
        minDist = dist;
        closest = enemy;
      }
    }

    return closest;
  }
}
