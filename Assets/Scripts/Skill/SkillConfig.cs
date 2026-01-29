[System.Serializable]
public class SkillConfig
{
  public int id;
  public string Name;
  public string SkillType;
  public float Cooldown;

  // 行为参数
  public int BuffId;
  public float DamageRate;
  public float CastRange;

  public string IconPath;
}
