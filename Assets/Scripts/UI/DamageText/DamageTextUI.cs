using UnityEngine;
using TMPro;

public class DamageTextUI : MonoBehaviour
{
  [SerializeField] private TMP_Text text;
  [SerializeField] private float floatSpeed = 50f;
  [SerializeField] private float lifeTime = 1f;

  private float timer;

  public void Init(int damage, bool isCritical)
  {
    text.text = damage.ToString();

    if (isCritical)
    {
      text.color = Color.red;
      text.fontSize = 40;
    }
    else
    {
      text.color = Color.white;
      text.fontSize = 28;
    }

    timer = lifeTime;
  }

  void Update()
  {
    transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    timer -= Time.deltaTime;

    if (timer <= 0f)
    {
      Destroy(gameObject);
    }
  }
}
