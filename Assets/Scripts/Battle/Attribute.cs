using System;

public class Attribute
{
  public int BaseValue { get; private set; }

  private int addValue;
  private float mulValue = 1f;
  private int finalValue;
  public int FinalValue => finalValue;

  public event Action<int> OnValueChanged;

  public Attribute(int baseValue)
  {
    BaseValue = baseValue;
    Recalculate();
  }

  public void Recalculate()
  {
    int oldValue = finalValue;
    finalValue = (int)(BaseValue * mulValue + addValue);

    if (oldValue != finalValue)
    {
      OnValueChanged?.Invoke(finalValue);
    }
  }

  // 固定加成
  // 百分比加成（0.2 = +20%）
  public void AddModifier(int add, float mul)
  {
    addValue += add;
    mulValue += mul;
    Recalculate();
  }

  public void RemoveModifier(int add, float mul)
  {
    addValue -= add;
    mulValue -= mul;
    Recalculate();
  }

}
