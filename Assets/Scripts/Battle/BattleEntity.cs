using System;
using System.Collections.Generic;

public enum Team
{
    Player,
    Enemy
}

public class BattleEntity
{
    public int Id;
    public string Name;
    public Team Team;

    public Attribute MaxHP { get; private set; }
    public Attribute ATK { get; private set; }
    public Attribute DEF { get; private set; }
    public Attribute CritRate { get; private set; }
    public Attribute CritDamage { get; private set; }
    public List<int> SkillsId { get; private set; }
    public List<SkillInstance> Skills { get; private set; }
    public int HP { get; private set; }

    public EntityView View { get; set; }
    public BuffController Buffs { get; private set; }

    public event Action<int, int> OnHPChanged; // current, max
    public event Action<int, bool, EntityView> OnDamaged; // damage, crit
    public event Action<BattleEntity> OnDeath;

    public bool IsDead => HP <= 0;

    public BattleEntity(EntityConfig config)
    {
        Id = config.id;
        Name = config.name;
        Team = config.team == "Player" ? Team.Player : Team.Enemy;
        ATK = new Attribute(config.atk);
        DEF = new Attribute(config.def);
        CritRate = new Attribute(config.critRate);
        CritDamage = new Attribute(config.critDmg);
        MaxHP = new Attribute(config.maxHp);
        HP = config.maxHp;
        Skills = new List<SkillInstance>();
        SkillsId = new List<int>();
        Buffs = new BuffController();
    }

    public void AddSkill(Skill skill, SkillConfig config)
    {
        Skills.Add(new SkillInstance(skill, config));
    }

    public void TakeDamage(int damage, bool isCrit)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Die();
        }

        OnHPChanged?.Invoke(HP, MaxHP.FinalValue);
        OnDamaged?.Invoke(damage, isCrit, View);
    }

    public void Die()
    {
        OnDeath?.Invoke(this);
    }
}