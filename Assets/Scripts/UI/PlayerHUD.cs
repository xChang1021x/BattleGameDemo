using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
  [SerializeField] private Image hpFill;

  private BattleEntity player;

  public void Bind(BattleEntity entity)
  {
    player = entity;
    RefreshHP();
    player.OnHPChanged += OnHPChanged;
  }

  void OnDestroy()
  {
    if (player != null)
      player.OnHPChanged -= OnHPChanged;
  }

  void OnHPChanged(int cur, int max)
  {
    RefreshHP();
  }

  void RefreshHP()
  {
    hpFill.fillAmount =
        (float)player.HP / player.MaxHP.FinalValue;
  }
}
