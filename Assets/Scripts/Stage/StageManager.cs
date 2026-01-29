using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [Header("Spawn Points")]
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private List<Transform> enemySpawnPoints;

    [Header("Stage Config")]
    [SerializeField] private int totalWaves = 2;
    [SerializeField] private float nextWaveDelay = 2f;

    [Header("UI Config")]
    [SerializeField] private ResultPanelUI resultPanel;
    [SerializeField] private GameObject enemyHudPrefab;
    [SerializeField] private Transform enemyHudContainer;
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private Vector3 offset = new(0, 2.2f, 0);
    [SerializeField] private Transform damageTextContainer;

    private BattleEntity playerEntity;
    private readonly List<BattleEntity> aliveEnemies = new();

    private int currentWaveIndex = 0;
    private bool stageFinished = false;

    #region Unity Lifecycle

    void Start()
    {

        // 1. 加载配置
        ConfigManager.Load();

        // 2. 清空战斗上下文
        BattleContext.Clear();

        // 3. 生成玩家
        SpawnPlayer();

        // 4. 开始第一波
        StartWave(0);
    }

    #endregion

    #region Player

    void SpawnPlayer()
    {
        playerEntity = EntityFactory.CreateEntity(
            entityId: 1,
            prefab: playerPrefab,
            position: playerSpawnPoint.position
        );

        BattleContext.SetPlayer(playerEntity);

        // 绑定技能控制器
        PlayerSkillController skillController =
            playerEntity.View.GetComponent<PlayerSkillController>();
        skillController.Bind(playerEntity);

        GlobalBuffController globalBuffController =
            playerEntity.View.GetComponent<GlobalBuffController>();
        globalBuffController.Bind(playerEntity);

        // 初始化技能 UI
        SkillPanelUI skillPanel =
            FindObjectOfType<SkillPanelUI>();
        skillPanel.Bind(playerEntity, skillController);

        PlayerHUD hud =
            FindObjectOfType<PlayerHUD>();
        hud.Bind(playerEntity);

        BuffPanelUI buffUI =
            hud.GetComponentInChildren<BuffPanelUI>();
        buffUI.Bind(playerEntity);

        playerEntity.OnDamaged += OnDamaged;
        // 监听玩家死亡
        playerEntity.OnDeath += OnPlayerDead;
    }

    void OnPlayerDead(BattleEntity player)
    {
        if (stageFinished) return;

        stageFinished = true;
        Debug.Log("Player Dead - Stage Failed");

        // TODO: 弹出失败 UI
        resultPanel.ShowFail();
    }

    #endregion

    #region Wave & Enemy

    void StartWave(int waveIndex)
    {
        if (stageFinished) return;

        Debug.Log($"Start Wave {waveIndex + 1}");

        currentWaveIndex = waveIndex;
        aliveEnemies.Clear();

        foreach (Transform spawnPoint in enemySpawnPoints)
        {
            SpawnEnemy(spawnPoint.position);
        }
    }

    void SpawnEnemy(Vector3 position)
    {
        BattleEntity enemyEntity = EntityFactory.CreateEntity(
            entityId: 2,
            prefab: enemyPrefab,
            position: position
        );

        aliveEnemies.Add(enemyEntity);
        BattleContext.AddEnemy(enemyEntity);

        // 绑定技能
        EnemySkillController skillController =
            enemyEntity.View.GetComponent<EnemySkillController>();
        skillController.Bind(enemyEntity);

        GlobalBuffController globalBuffController =
            enemyEntity.View.GetComponent<GlobalBuffController>();
        globalBuffController.Bind(enemyEntity);

        EnemyHUD hud =
            Instantiate(enemyHudPrefab,
        enemyHudContainer.transform).GetComponent<EnemyHUD>();
        hud.Bind(enemyEntity);

        BuffPanelUI buffUI =
            hud.GetComponentInChildren<BuffPanelUI>();
        buffUI.Bind(enemyEntity);



        enemyEntity.OnDamaged += OnDamaged;
        enemyEntity.OnDeath += OnEnemyDead;
    }

    void OnDamaged(int damage, bool isCritical, EntityView target)
    {
        DamageTextUI text =
        Instantiate(damageTextPrefab, damageTextContainer.transform).GetComponent<DamageTextUI>();

        Vector3 screenPos =
            Camera.main.WorldToScreenPoint(target.transform.position + offset);

        transform.position = screenPos;
        text.transform.position = screenPos;
        text.Init(damage, isCritical);
    }

    void OnEnemyDead(BattleEntity enemy)
    {
        enemy.OnDeath -= OnEnemyDead;

        aliveEnemies.Remove(enemy);
        BattleContext.RemoveEnemy(enemy);

        CheckWaveClear();
    }

    void CheckWaveClear()
    {
        if (aliveEnemies.Count > 0) return;

        Debug.Log($"Wave {currentWaveIndex + 1} Clear");

        if (currentWaveIndex + 1 >= totalWaves)
        {
            OnStageClear();
        }
        else
        {
            Invoke(nameof(StartNextWave), nextWaveDelay);
        }
    }

    void StartNextWave()
    {
        StartWave(currentWaveIndex + 1);
    }

    #endregion

    #region Stage Result

    void OnStageClear()
    {
        if (stageFinished) return;

        stageFinished = true;
        Debug.Log("Stage Clear!");

        // TODO: 弹出胜利 UI
        resultPanel.ShowWin();
    }

    #endregion

    #region Debug / Restart (可选)

    public void RestartStage()
    {
        // 清理敌人
        foreach (var enemy in aliveEnemies)
        {
            if (enemy?.View != null)
            {
                Destroy(enemy.View.gameObject);
            }
        }
        aliveEnemies.Clear();

        // 清理玩家
        if (playerEntity?.View != null)
        {
            Destroy(playerEntity.View.gameObject);
        }

        BattleContext.Clear();
        currentWaveIndex = 0;
        stageFinished = false;

        Start();
    }

    #endregion
}
