using System.Collections;
using UnityEngine;

public class EntityView : MonoBehaviour
{
  public BattleEntity Entity { get; private set; }

  public void Bind(BattleEntity entity)
  {
    Entity = entity;
    entity.OnDeath += OnEntityDeath;
  }

  void OnEntityDeath(BattleEntity entity)
  {
    StartCoroutine(DeathRoutine());
  }

  protected virtual IEnumerator DeathRoutine()
  {
    // 1️⃣ 禁用控制
    DisableControl();

    // 2️⃣ 播放动画（如果有）
    yield return new WaitForSeconds(0.5f);

    // 3️⃣ 通知回收
    OnDeathEffectFinished();
  }

  protected virtual void DisableControl()
  {
    // 子类实现
  }

  protected virtual void OnDeathEffectFinished()
  {
    ObjectPoolManager.Release(gameObject);
  }
}
