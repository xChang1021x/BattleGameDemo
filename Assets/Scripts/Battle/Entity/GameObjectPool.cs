using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool
{
  private readonly GameObject prefab;
  private readonly Stack<GameObject> pool = new();

  public GameObjectPool(GameObject prefab)
  {
    this.prefab = prefab;
  }

  public GameObject Get(Vector3 pos)
  {
    GameObject go =
        pool.Count > 0
        ? pool.Pop()
        : GameObject.Instantiate(prefab);

    go.transform.position = pos;
    go.SetActive(true);
    return go;
  }

  public void Release(GameObject go)
  {
    go.SetActive(false);
    pool.Push(go);
  }
}
