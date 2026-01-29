using UnityEngine;
using UnityEngine.UI;

public class BuffIconUI : MonoBehaviour
{
  [SerializeField] private Image icon;
  [SerializeField] private Image timeMask;

  private BuffInstance buff;

  public void Bind(BuffInstance instance)
  {
    buff = instance;

    LoadIcon(instance.Config.IconPath);
  }

  void Update()
  {
    if (buff == null) return;

    float ratio =
        Mathf.Clamp01(buff.RemainingTime /
                      buff.Config.Duration);

    timeMask.fillAmount = 1 - ratio;
  }

  private void LoadIcon(string path)
  {
    icon.sprite = Resources.Load<Sprite>(path);
  }
}
