using UnityEngine;

public class SkillPanelUI : MonoBehaviour
{
  [SerializeField] private SkillButtonUI buttonPrefab;
  [SerializeField] private Transform root;

  public void Bind(
      BattleEntity caster,
      PlayerSkillController playerSkillController)
  {
    foreach (var skill in caster.Skills)
    {
      SkillButtonUI btn = Instantiate(buttonPrefab, root);
      btn.Bind(skill, playerSkillController);
    }
  }
}
