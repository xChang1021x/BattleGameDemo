using System.Collections.Generic;
using UnityEngine;

public class ConfigManager
{
  public static Dictionary<int, EntityConfig> EntityConfigs;
  public static Dictionary<int, SkillConfig> SkillConfigs;
  public static Dictionary<int, BuffConfig> BuffConfigs;

  public static void Load()
  {
    SkillConfigs = LoadDict<SkillConfig>("Configs/skill");
    BuffConfigs = LoadDict<BuffConfig>("Configs/buff");
    EntityConfigs = LoadDict<EntityConfig>("Configs/entity");
  }

  private static Dictionary<int, T> LoadDict<T>(string path)
  {
    TextAsset text = Resources.Load<TextAsset>(path);
    return JsonUtility.FromJson<Wrapper<T>>(text.text).ToDict();
  }

  [System.Serializable]
  private class Wrapper<T>
  {
    public List<T> list;

    public Dictionary<int, T> ToDict()
    {
      var dict = new Dictionary<int, T>();
      foreach (var item in list)
      {
        int id = (int)item.GetType().GetField("id").GetValue(item);
        dict[id] = item;
      }
      return dict;
    }
  }
}
