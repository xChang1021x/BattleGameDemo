using UnityEngine;
using UnityEngine.UI;

public class SkillButtonUI : MonoBehaviour
{
  [SerializeField] private Button button;
  [SerializeField] private Image icon;
  [SerializeField] private Image cdMask;

  private SkillInstance skill;
  private PlayerSkillController controller;

  public void Bind(
      SkillInstance skillInstance,
      PlayerSkillController skillController)
  {
    skill = skillInstance;
    controller = skillController;

    LoadIcon(skill.Config.IconPath);

    button.onClick.AddListener(OnClick);
  }

  void Update()
  {
    if (skill == null) return;

    cdMask.fillAmount =
        skill.RemainingCD / skill.Config.Cooldown;
  }

  void OnClick()
  {
    controller.TryCastSkill(skill);
  }

  void LoadIcon(string path)
  {
    icon.sprite = Resources.Load<Sprite>(path);
  }
}
