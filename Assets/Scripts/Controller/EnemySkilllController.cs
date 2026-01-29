using UnityEngine;

public class EnemySkillController : MonoBehaviour
{
  BattleEntity enemy;

  public void Bind(BattleEntity entity)
  {
    enemy = entity;
  }

  void Update()
  {
    float dt = Time.deltaTime;

    foreach (var skill in enemy.Skills)
    {
      skill.Tick(dt);
    }
  }
}
