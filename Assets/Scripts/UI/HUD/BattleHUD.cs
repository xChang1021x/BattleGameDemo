using UnityEngine.UI;
using TMPro;
using UnityEngine; // 如果你用 TextMeshPro

public class BattleHUD : MonoBehaviour
{
  [SerializeField] private Slider hpBar;
  [SerializeField] private TMP_Text hpText;

  private BattleEntity boundEntity;

  public void Bind(BattleEntity entity)
  {
    boundEntity = entity;
    entity.OnHPChanged += RefreshHP;
    RefreshHP(entity.HP, entity.MaxHP.FinalValue);
  }

  private void RefreshHP(int current, int max)
  {
    hpBar.maxValue = max;
    hpBar.value = current;
    hpText.text = $"{current} / {max}";
  }

  private void OnDestroy()
  {
    if (boundEntity != null)
    {
      boundEntity.OnHPChanged -= RefreshHP;
    }
  }
}
