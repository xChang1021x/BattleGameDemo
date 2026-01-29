// using FairyGUI;
// using UnityEngine;

// public class BattleTest : MonoBehaviour
// {
//   private BattleSystem battle;
//   [SerializeField] private BattleHUD hud;
//   [SerializeField] private SkillPanelUI skillPanel;
//   [SerializeField] private BuffPanelUI buffPanel;
//   private BattleEntity player;
//   private BattleEntity enemy;

//   void Start()
//   {
//     ConfigManager.Load();

//     battle = new BattleSystem();

//     battle.Player = EntityFactory.Create(1);

//     battle.Enemies.Add(EntityFactory.Create(2));

//     battle.Enemies[0].OnDamaged += (damage, isCrit) =>
//     {
//       DamageTextManager.Instance.SpawnDamageText(
//             Vector3.zero,
//             damage,
//             isCrit);
//     };

//     skillPanel.Bind(battle.Player, battle.Enemies[0]);
//     buffPanel.Bind(battle.Enemies[0]);
//     hud.Bind(battle.Enemies[0]);
//   }

//   void TestDamage()
//   {
//     battle.Player.TakeDamage(Random.Range(10, 30), true);
//   }

//   void Update()
//   {
//     battle.Update(Time.deltaTime);

//     if (Input.GetKeyDown(KeyCode.Space))
//     {
//       var target = battle.GetFirstAliveEnemy();
//       if (target != null)
//         battle.Player.Skills[0].TryCast(battle.Player, target);
//     }
//     if (Input.GetKeyDown(KeyCode.A))
//     {
//       var target = battle.GetFirstAliveEnemy();
//       if (target != null)
//         battle.Player.Skills[1].TryCast(battle.Player, target);
//     }
//   }
// }
