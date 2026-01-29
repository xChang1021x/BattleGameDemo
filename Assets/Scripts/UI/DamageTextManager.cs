using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
  public static DamageTextManager Instance { get; private set; }

  [SerializeField] private DamageTextUI damageTextPrefab;
  [SerializeField] private RectTransform root;

  private void Awake()
  {
    Instance = this;
  }

  public void SpawnDamageText(
      Vector3 worldPos,
      int damage,
      bool isCritical)
  {
    DamageTextUI text =
        Instantiate(damageTextPrefab, root);

    Vector3 screenPos =
        Camera.main.WorldToScreenPoint(worldPos);

    text.transform.position = screenPos;
    text.Init(damage, isCritical);
  }
}
