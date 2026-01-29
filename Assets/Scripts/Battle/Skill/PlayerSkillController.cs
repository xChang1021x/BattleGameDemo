using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
  private BattleEntity player;

  public void Bind(BattleEntity playerEntity)
  {
    player = playerEntity;
  }

  void Update()
  {
    float dt = Time.deltaTime;

    foreach (SkillInstance skill in player.Skills)
    {
      skill.Tick(dt);
    }
  }

  public void TryCastSkill(SkillInstance skill)
  {
    if (player == null) return;

    BattleEntity target =
        PlayerTargetingSystem.FindClosestEnemy(
            player,
            skill.Config.CastRange
        );

    if (target == null)
    {
      Debug.Log("No target");
      return;
    }

    skill.TryCast(player, target);
  }
}
