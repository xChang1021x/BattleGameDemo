using UnityEngine;

public class EnemyDamageText : MonoBehaviour
{
  [SerializeField] private DamageTextUI damageTextPrefab;
  [SerializeField] private Vector3 offset = new(0, 2.2f, 0);
  private BattleEntity enemy;
  private Transform target;

  public void Bind(BattleEntity entity)
  {
    enemy = entity;
    target = entity.View.transform;

    entity.OnDamaged += OnDamaged;
  }

  void OnDamaged(int damage, bool isCritical, EntityView target)
  {
    DamageTextUI text =
        Instantiate(damageTextPrefab, transform.position + offset, Quaternion.identity);

    Vector3 screenPos =
        Camera.main.WorldToScreenPoint(target.transform.position + offset);

    transform.position = screenPos;
    text.transform.position = screenPos;
    text.Init(damage, isCritical);
  }
}
