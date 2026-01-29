// using System.Collections.Generic;
// using System.Linq;

// public class BattleSystem
// {
//   public BattleEntity Player;
//   public List<BattleEntity> Enemies = new();
//   public List<Skill> PlayerSkills = new();

//   public void Update(float deltaTime)
//   {
//     Player.Update(deltaTime);
//     foreach (var e in Enemies)
//     {
//       e.Update(deltaTime);
//     }

//   }

//   public BattleEntity GetFirstAliveEnemy()
//   {
//     return Enemies.FirstOrDefault(e => !e.IsDead);
//   }
// }