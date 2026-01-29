using System.Collections.Generic;
using UnityEngine;


public static class EntityFactory
{
  public static BattleEntity CreateEntity(
    int entityId,
    GameObject prefab,
    Vector3 position)
  {
    EntityConfig config =
        ConfigManager.EntityConfigs[entityId];

    GameObject go =
        GameObject.Instantiate(prefab, position, Quaternion.identity);

    EntityView view = go.GetComponent<EntityView>();


    if (view == null)
      view = go.AddComponent<EntityView>();



    BattleEntity entity = new BattleEntity(config);

    view.Bind(entity);
    entity.View = view; // 可选：反向引用

    // 挂技能
    foreach (int skillId in config.skills)
    {
      SkillConfig skillCfg = ConfigManager.SkillConfigs[skillId];
      Skill skill = SkillFactory.Create(skillCfg);
      entity.AddSkill(skill, skillCfg);
    }

    return entity;
  }
}
