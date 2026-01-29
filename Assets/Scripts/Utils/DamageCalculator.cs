using UnityEngine;

public static class DamageCalculator
{
  public static int Calculate(DamageContext ctx)
  {
    int atk = ctx.Attacker.ATK.FinalValue;
    int def = ctx.Defender.DEF.FinalValue;

    // 1️⃣ 基础伤害
    float damage = atk * 100f / (100f + def);

    // 2️⃣ 暴击判定
    int critRate = ctx.Attacker.CritRate.FinalValue; // 比如 25
    int rand = Random.Range(0, 100);

    if (rand < critRate)
    {
      ctx.IsCritical = true;
      float critMul = ctx.Attacker.CritDamage.FinalValue / 100f;
      damage *= critMul;
    }

    // 3️⃣ 随机浮动（±5%）
    float variance = Random.Range(0.95f, 1.05f);
    damage *= variance;

    int finalDamage = Mathf.Max(1, Mathf.FloorToInt(damage));

    ctx.FinalDamage = finalDamage;
    return finalDamage;
  }
}
