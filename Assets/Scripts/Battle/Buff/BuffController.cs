using System;
using System.Collections.Generic;

public class BuffController
{
  public List<BuffInstance> buffs = new();

  public event Action<BuffInstance> OnBuffAdded;
  public event Action<BuffInstance> OnBuffRemoved;

  public void AddBuff(BuffInstance buff, BattleEntity target)
  {
    buffs.Add(buff);
    buff.Buff.OnAdd(target);

    OnBuffAdded?.Invoke(buff);
  }

  public void Update(BattleEntity target, float dt)
  {
    for (int i = buffs.Count - 1; i >= 0; i--)
    {
      buffs[i].Buff.OnUpdate(target, dt);
      buffs[i].Tick(dt);
      if (buffs[i].IsExpired)
      {
        buffs[i].Buff.OnRemove(target);
        buffs.RemoveAt(i);
        OnBuffRemoved?.Invoke(buffs[i]);
      }
    }
  }

  public IReadOnlyList<BuffInstance> GetAll()
  {
    return buffs;
  }
}
