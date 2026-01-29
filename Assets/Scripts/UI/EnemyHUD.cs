using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
  [SerializeField] private Image hpFill;
  [SerializeField] private Vector3 offset = new(0, 2.2f, 0);

  private BattleEntity enemy;
  private Transform target;
  private Camera cam;

  public void Bind(BattleEntity entity)
  {
    enemy = entity;
    target = entity.View.transform;
    cam = Camera.main;

    enemy.OnHPChanged += OnHPChanged;
    enemy.OnDeath += OnDeath;

    RefreshHP();
  }

  void LateUpdate()
  {
    if (target == null) return;

    Vector3 screenPos =
        cam.WorldToScreenPoint(target.position + offset);

    transform.position = screenPos;
  }

  void OnHPChanged(int cur, int max)
  {
    RefreshHP();
  }

  void RefreshHP()
  {
    hpFill.fillAmount =
        (float)enemy.HP / enemy.MaxHP.FinalValue;
  }

  void OnDeath(BattleEntity e)
  {
    Destroy(gameObject);
  }
}
