using UnityEngine;

public class GlobalBuffController : MonoBehaviour
{
  private BattleEntity owner;

  public void Bind(BattleEntity entity)
  {
    owner = entity;
  }

  void Update()
  {
    float dt = Time.deltaTime;

    owner.Buffs.Update(owner, dt);
  }
}
