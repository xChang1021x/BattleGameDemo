using System.Collections.Generic;
using UnityEngine;

public class BuffPanelUI : MonoBehaviour
{
  [SerializeField] private BuffIconUI iconPrefab;
  [SerializeField] private Transform root;

  private Dictionary<BuffInstance, BuffIconUI> map =
      new Dictionary<BuffInstance, BuffIconUI>();

  public void Bind(BattleEntity entity)
  {
    entity.Buffs.OnBuffAdded += OnBuffAdded;
    entity.Buffs.OnBuffRemoved += OnBuffRemoved;
  }

  private void OnBuffAdded(BuffInstance buff)
  {
    BuffIconUI icon =
        Instantiate(iconPrefab, root);

    icon.Bind(buff);
    map[buff] = icon;
  }

  private void OnBuffRemoved(BuffInstance buff)
  {
    if (map.TryGetValue(buff, out var icon))
    {
      Destroy(icon.gameObject);
      map.Remove(buff);
    }
  }
}
