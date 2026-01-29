using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
  static Dictionary<string, GameObjectPool> pools
      = new();

  public static void Register(string key, GameObject prefab)
  {
    if (!pools.ContainsKey(key))
    {
      pools[key] = new GameObjectPool(prefab);
    }
  }

  public static GameObject Get(string key, Vector3 pos)
  {
    return pools[key].Get(pos);
  }

  public static void Release(GameObject go)
  {
    go.SetActive(false);
  }
}
